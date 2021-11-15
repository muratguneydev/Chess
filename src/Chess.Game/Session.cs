namespace Chess.Game;

public class Session
{
	private readonly Stack<Move> moves = new Stack<Move>();
	public event Action<Move>? OnMove;

	public Session(WhitePlayer whitePlayer, BlackPlayer blackPlayer)
	{
		this.WhitePlayer = whitePlayer;
		this.BlackPlayer = blackPlayer;
	}

	public bool IsComplete => false;

	public Winner Winner => EmptyWinner.Winner;

	public Color PlayTurn => this.CurrentPlayer.Color;
	public Player CurrentPlayer => this.moves.Any()
		? this.moves.Peek().Color == Color.Black ? this.WhitePlayer : this.BlackPlayer
		: this.WhitePlayer;

	public Player WaitingPlayer => this.CurrentPlayer == this.WhitePlayer
		? this.BlackPlayer
		: this.WhitePlayer;

	public void Start()
	{
		this.WhitePlayer.ResumePlaying();
	}

	public void Next(Move move)
	{
		if (!move.IsValid)
			return;

		this.moves.Push(move);
		this.SwitchTurns();
	}

	public Move Back()
	{
		if (!this.moves.Any())
			return EmptyMove.Move;
		
		var lastMove= this.moves.Pop();
		lastMove.GoBack();
		this.SwitchTurns();
		return lastMove;
	}

	public IEnumerable<Move> MoveHistory => this.moves;

	public WhitePlayer WhitePlayer { get; }
	public BlackPlayer BlackPlayer { get; }

	private void SwitchTurns()
	{
		this.WaitingPlayer.Wait();
		this.CurrentPlayer.ResumePlaying();
	}
}
