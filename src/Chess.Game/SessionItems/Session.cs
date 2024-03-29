using System.Text.Json.Serialization;

namespace Chess.Game;

public record Session
{
	private readonly MoveHistory moves;
	private readonly OnMoveEvent OnMove = new OnMoveEvent();
	private readonly SessionPlayers sessionPlayers;
	private readonly SessionPlayerRegistrar sessionPlayerRegistrar;
	private readonly SessionStateMachine sessionStateMachine;

	public Session(SessionPlayers sessionPlayers, SessionPlayerRegistrar sessionPlayerRegistrar, SessionStateMachine sessionStateMachine,
		Board board, MoveHistory moveHistory)
	{
		this.sessionPlayers = sessionPlayers;
		this.sessionPlayerRegistrar = sessionPlayerRegistrar;
		this.sessionStateMachine = sessionStateMachine;
		this.Board = board;
		this.moves = moveHistory;//new MoveHistory(board);
	}

	public bool IsComplete => false;
	public IEnumerable<Move> MoveHistory => this.moves.Select(x => x);
	public WhitePlayer WhitePlayer => this.sessionPlayers.WhitePlayer;
	public BlackPlayer BlackPlayer => this.sessionPlayers.BlackPlayer;
	public Winner Winner => EmptyWinner.Winner;
	public Color PlayTurn => this.CurrentPlayer.Color;
	public SessionState CurrentState => this.sessionStateMachine.CurrentState;

	public Player CurrentPlayer => this.CurrentState is SessionStateBlackMove //Note: Possible: this.moves.LastMove.Color == Color.White
		? this.BlackPlayer
		: this.WhitePlayer;

	public Player WaitingPlayer => this.CurrentPlayer == this.WhitePlayer
		? this.BlackPlayer
		: this.WhitePlayer;

	public Board Board { get; }
	public SessionPlayers SessionPlayers => this.sessionPlayers;
	public SessionPlayerRegistrar SessionPlayerRegistrar => this.sessionPlayerRegistrar;
	public SessionStateMachine SessionStateMachine => this.sessionStateMachine;


	public void Start()
	{
		this.WhitePlayer.ResumePlaying();
	}

	public Move Move(Move move)
	{
		if (!move.IsValid)
			return move;
		if (!this.CanMove(move))
			return new InvalidMove(move);

		var originalMove = move.Copy();
		
		move.Go();
		this.sessionStateMachine.Move();
		this.SwitchTurns();
		
		this.moves.Push(originalMove);
		this.OnMove.Invoke(originalMove);
		
		return move;
	}

	public Move Back()
	{
		if (!this.moves.Any())
			throw new InvalidTakeBackMoveException();
		
		this.sessionStateMachine.Back();
		var lastMove = this.moves.Pop();
		lastMove.GoBack();
		this.SwitchTurns();//TODO: add back tests then move this before goback() call.
		return lastMove;
	}

	public void AddMoveEventCallback(Action<Move> callback)
	{
		this.OnMove.MoveEvent += callback;
	}

	public void RegisterBlackPlayer(BlackPlayer player)
	{
		this.sessionStateMachine.RegisterBlack();
		this.sessionPlayerRegistrar.RegisterBlackPlayer(player);
	}

	public void RegisterWhitePlayer(WhitePlayer player)
	{
		this.sessionStateMachine.RegisterWhite();
		this.sessionPlayerRegistrar.RegisterWhitePlayer(player);
	}

	public void SetBlackPlayerReady()
	{
		this.sessionStateMachine.SetBlackReady();
		this.sessionPlayers.SetBlackPlayerReady();
	}

	public void SetWhitePlayerReady()
	{
		this.sessionStateMachine.SetWhiteReady();
		this.sessionPlayers.SetWhitePlayerReady();
	}

	public bool CanMove(Move move)
	{
		return this.IsTurnToPlay(move.From.Piece);
	}

	private bool IsTurnToPlay(IBoardPiece piece) => this.PlayTurn == piece.Color;

	private void SwitchTurns()
	{
		this.WaitingPlayer.Wait();
		this.CurrentPlayer.ResumePlaying();
	}
}
