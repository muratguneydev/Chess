namespace Chess.Game;

public abstract class BoardPieceDecorator : IBoardPiece
{
	private readonly Piece originalPiece;
	private readonly CellHistory cellHistory;

	public BoardPieceDecorator(Piece originalPiece, Board board, CellHistory cellHistory)
	{
		this.originalPiece = originalPiece;
		this.Board = board;
		this.cellHistory = cellHistory;
	}

	public abstract Color Color { get; }
	public Board Board { get; }

	public bool IsBlack => this.Color == Color.Black;
	public bool IsWhite => this.Color == Color.White;
	public bool IsEmpty => this is EmptyBoardPiece;
	public bool IsFirstMove => this.cellHistory.IsFirstMove;
	public Cell PreviousCell => this.cellHistory.GetPrevious();
	
	public bool HasSameColor(IBoardPiece otherBoardPiece) => this.Color == otherBoardPiece.Color;

	public bool IsOfType(Type type)
	{
		return type.IsAssignableFrom(this.originalPiece.GetType());
	}

	public virtual bool CanMove(Move move)
	{
		return
			this.GetMovePath(move).IsValid
			&& this.ThereArentAnyBlockingPiecesInBetween(move)
			&& !this.HasSameColor(move.To.Piece);
	}

	public MovePath GetMovePath(Move move)
	{
		return this.originalPiece.GetMovePath(move);
	}

	public void RecordCurrentCellInHistory(Cell cell)
	{
		this.cellHistory.Push(cell);
	}

	public Cell PopLastCellFromHistory()
	{
		if (this.cellHistory.IsEmpty)
			return this.Board.EmptyCell;

		return this.cellHistory.Pop();
	}

	private bool ThereArentAnyBlockingPiecesInBetween(Move move)
	{
		var movePath = this.originalPiece.GetMovePath(move);
		return !this.Board.GetPiecesInCoordinates(movePath.CoordinatesInPath)
							.Any();
	}
}