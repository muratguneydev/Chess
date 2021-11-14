namespace Chess.Game;

public abstract class BoardPieceDecorator : IBoardPiece
{
	private readonly Piece originalPiece;
	private readonly Session session;
	private readonly Board board;

	public BoardPieceDecorator(Piece originalPiece, Session session, Board board, Cell initialCell)
	{
		this.originalPiece = originalPiece;
		this.session = session;
		this.board = board;
		this.CurrentCell = initialCell;
		this.PieceType = originalPiece.GetType();
	}

	public abstract Color Color { get; }
	public Type PieceType { get; }

	public bool IsEmpty => this is EmptyBoardPiece;

	public Cell CurrentCell { get; private set; }

	public bool HasSameColor(IBoardPiece otherBoardPiece) => this.Color == otherBoardPiece.Color;

	public Move Move(Cell cellDestination)
	{
		if (!this.CanMove(cellDestination))
			return new InvalidMove(this.CurrentCell, cellDestination);

		var move = new Move(this.CurrentCell, cellDestination);
		cellDestination.Initialize(this.CurrentCell.Piece);
		this.CurrentCell.MakeEmpty();
		var previousCell = this.CurrentCell;
		this.CurrentCell = cellDestination;
		
		return move;
	}

	public virtual bool CanMove(Cell cellDestination)
	{
		return
			this.IsTurnToPlay
			&& !this.CurrentCell.Equals(cellDestination)
			&& this.originalPiece.GetMovePath(new Move(this.CurrentCell, cellDestination)).IsValid
			&& this.ThereArentAnyBlockingPiecesInBetween(cellDestination)
			&& !this.HasSameColor(cellDestination.Piece);
	}

	private bool ThereArentAnyBlockingPiecesInBetween(Cell cellDestination)
	{
		var movePath = this.originalPiece.GetMovePath(new Move(this.CurrentCell, cellDestination));
		return !this.board.GetPiecesInCoordinates(movePath.CoordinatesInPath)
							.Any();
	}

	private bool IsTurnToPlay => this.session.PlayTurn == this.Color;
}
