namespace Chess.Game
{
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
			this.PlayTurn = Color.White;
		}

		public bool IsComplete => false;

		public Winner Winner => EmptyWinner.Winner;

		public Color PlayTurn { get; private set; }

		public void Start()
		{
			
		}

		public void Next(Move move)
		{
			if (!move.IsValid)
				return;
			
			this.moves.Push(move);
			this.PlayTurn = move.Color == Color.Black ? Color.White : Color.Black;
		}

		public Move Back()
		{
			if (!this.moves.Any())
				return EmptyMove.Move;
			
			var move = this.moves.Pop();
			this.PlayTurn = move.Color;
			return move;
		}

		public IEnumerable<Move> MoveHistory => this.moves;
	}
}