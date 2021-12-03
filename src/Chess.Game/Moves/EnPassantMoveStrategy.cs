namespace Chess.Game;

public class EnPassantMoveStrategy : IMoveStrategy
{
	private readonly Board board;

	public EnPassantMoveStrategy(Board board)
	{
		this.board = board;
	}
	public MovePath GetMovePath(Move move)
	{
		var leftCellPiece = this.board.Table[move.From.X - 1, move.From.Y+1];
		var rightCellPiece = this.board.Table[move.From.X + 1, move.From.Y+1];
		if (move.To.IsOccupied
			|| LeftMoveIsValid(move, leftCellPiece)
			|| RightMoveIsValid(move, rightCellPiece))
		{
			return new InvalidMovePath(move);
		}

		return new MovePath(move, Enumerable.Empty<Coordinate>());
	}

	private bool LeftMoveIsValid(Move move, Cell leftCellPiece)
	{
		return (move.To.Equals(leftCellPiece) && !this.IsLeftCellValid(move.From));
	}

	private bool IsLeftCellValid(Cell fromCell)
	{
		var leftNeighbourCell = this.board.Table[fromCell.X-1, fromCell.Y];
		return leftNeighbourCell.IsOccupied
			&& !leftNeighbourCell.Piece.HasSameColor(fromCell.Piece)
			&& leftNeighbourCell.Piece is Pawn;
	}

	private bool RightMoveIsValid(Move move, Cell rightCellPiece)
	{
		return (move.To.Equals(rightCellPiece) && !this.IsRightCellValid(move.From));
	}

	private bool IsRightCellValid(Cell fromCell)
	{
		var rightNeighbourCell = this.board.Table[fromCell.X-1, fromCell.Y];
		return rightNeighbourCell.IsOccupied
			&& !rightNeighbourCell.Piece.HasSameColor(fromCell.Piece)
			&& rightNeighbourCell.Piece is Pawn;
	}
}