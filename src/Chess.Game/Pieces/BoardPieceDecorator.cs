namespace Chess.Game;

public abstract class BoardPieceDecorator : IBoardPiece
{
	private readonly Piece originalPiece;
	private readonly Session session;
	private readonly CellHistory cellHistory = new CellHistory();

	public BoardPieceDecorator(Piece originalPiece, Session session, Board board, CellHistory cellHistory)
	{
		this.originalPiece = originalPiece;
		this.session = session;
		this.Board = board;
		this.PieceType = originalPiece.GetType();
		this.cellHistory = cellHistory;
	}

	public abstract Color Color { get; }
	public Type PieceType { get; }
	public Board Board { get; }

	public bool IsEmpty => this is EmptyBoardPiece;

	public bool HasSameColor(IBoardPiece otherBoardPiece) => this.Color == otherBoardPiece.Color;

	public virtual bool CanMove(Move move)
	{
		return
			this.IsTurnToPlay
			//&& !from.Equals(to)
			&& this.GetMovePath(move).IsValid
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
			return EmptyCell.Cell;

		return this.cellHistory.Pop();
	}

	public bool IsFirstMove => this.cellHistory.IsFirstMove;
	public Cell PreviousCell => this.cellHistory.GetPrevious();

	private bool ThereArentAnyBlockingPiecesInBetween(Move move)
	{
		var movePath = this.originalPiece.GetMovePath(move);
		return !this.Board.GetPiecesInCoordinates(movePath.CoordinatesInPath)
							.Any();
	}

	private bool IsTurnToPlay => this.session.PlayTurn == this.Color;
}