namespace Chess.Game;

public abstract record BoardPieceDecorator : IBoardPiece
{
	private readonly Piece originalPiece;
	private readonly CellHistory cellHistory;

	public BoardPieceDecorator(Piece originalPiece, CellHistory cellHistory)
	{
		this.originalPiece = originalPiece;
		//this.Board = board;
		this.cellHistory = cellHistory;
	}

	public abstract Color Color { get; }
	//private Board Board { get; }

	public bool IsBlack => this.Color == Color.Black;
	public bool IsWhite => this.Color == Color.White;
	public bool IsEmpty => this is EmptyBoardPiece;
	public bool IsFirstMove => this.cellHistory.IsFirstMove;
	public Coordinate PreviousCoordinate => this.cellHistory.GetPrevious();

	//for serialization
	public CellHistory CellHistory => this.cellHistory;

	public Type OriginalPieceType => this.originalPiece.GetType();
	
	public bool HasSameColor(IBoardPiece otherBoardPiece) => this.Color == otherBoardPiece.Color;

	public bool IsOfType(Type type)
	{
		//return type.IsAssignableFrom(this.originalPiece.GetType());
		return type.IsAssignableFrom(this.OriginalPieceType);
	}

	public virtual bool CanMove(Move move)
	{
		return
			this.GetMovePath(move).IsValid
			&& move.ThereArentAnyBlockingPiecesInBetween()
			&& !this.HasSameColor(move.To.Piece);
	}

	public MovePath GetMovePath(Move move)
	{
		return this.originalPiece.GetMovePath(move);
	}

	public void RecordCurrentCellInHistory(Coordinate coordinate)
	{
		this.cellHistory.Push(coordinate);
	}

	public void PopLastCellFromHistory()
	{
		if (this.cellHistory.IsEmpty)
			return;// this.Board.EmptyCell;

		this.cellHistory.Pop();
	}

	// private bool ThereArentAnyBlockingPiecesInBetween(Move move)
	// {
	// 	var movePath = this.originalPiece.GetMovePath(move);
	// 	return !this.Board.GetPiecesInCoordinates(movePath.CoordinatesInPath)
	// 						.Any();
	// }
}