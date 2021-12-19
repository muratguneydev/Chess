namespace Chess.Game;

public abstract class BoardPieceDecorator : IBoardPiece
{
	private readonly Piece originalPiece;
	private readonly Session session;
	private readonly Board board;
	private readonly CellHistory cellHistory = new CellHistory();

	public BoardPieceDecorator(Piece originalPiece, Session session, Board board, CellHistory cellHistory)
	{
		this.originalPiece = originalPiece;
		this.session = session;
		this.board = board;
		this.PieceType = originalPiece.GetType();
		this.cellHistory = cellHistory;
	}

	public abstract Color Color { get; }
	public Type PieceType { get; }

	public bool IsEmpty => this is EmptyBoardPiece;

	public bool HasSameColor(IBoardPiece otherBoardPiece) => this.Color == otherBoardPiece.Color;

	public virtual bool CanMove(Cell from, Cell cellDestination)
	{
		return
			this.IsTurnToPlay
			&& !from.Equals(cellDestination)
			&& this.originalPiece.GetMovePath(new Move(from, cellDestination)).IsValid
			&& this.ThereArentAnyBlockingPiecesInBetween(from, cellDestination)
			&& !this.HasSameColor(cellDestination.Piece);
	}

	public void RecordCurrentCellInHistory(Cell cell)
	{
		this.cellHistory.Push(cell);
	}

	public Cell PopLastCellFromHistory()
	{
		if (this.cellHistory.IsEmpty)
			return EmptyCell.Cell;

		return this.cellHistory.Pop();
	}

	public bool IsFirstMove => this.cellHistory.IsFirstMove;
	public Cell PreviousCell => this.cellHistory.GetPrevious();

	private bool ThereArentAnyBlockingPiecesInBetween(Cell from, Cell cellDestination)
	{
		var movePath = this.originalPiece.GetMovePath(new Move(from, cellDestination));
		return !this.board.GetPiecesInCoordinates(movePath.CoordinatesInPath)
							.Any();
	}

	private bool IsTurnToPlay => this.session.PlayTurn == this.Color;
}