namespace Chess.Game;

public class Session
{
	private readonly WhitePlayer whitePlayer;
	private readonly BlackPlayer blackPlayer;
	private readonly Stack<Move> moves = new Stack<Move>();
	public event Action<Move>? OnMove;

	public Session(WhitePlayer whitePlayer, BlackPlayer blackPlayer)
	{
		this.whitePlayer = whitePlayer;
		this.blackPlayer = blackPlayer;
	}

	public bool IsComplete => false;

	public Winner Winner => EmptyWinner.Winner;

	public Color PlayTurn => this.CurrentPlayer.Color;
	public Player CurrentPlayer => this.moves.Any()
		? this.moves.Peek().Color == Color.Black ? this.whitePlayer : this.blackPlayer
		: this.whitePlayer;

	public Player WaitingPlayer => this.CurrentPlayer == this.whitePlayer
		? this.blackPlayer
		: this.whitePlayer;

	public void Start()
	{
		this.whitePlayer.ResumePlaying();
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
		this.SwitchTurns();
		return lastMove;
	}

	public IEnumerable<Move> MoveHistory => this.moves;

	private void SwitchTurns()
	{
		this.WaitingPlayer.Wait();
		this.CurrentPlayer.ResumePlaying();
	}
}
