namespace Chess.Game;

public abstract class EnPassantMoveStrategy : IMoveStrategy
{
	private readonly Board board;
	private readonly YDirection yDirection;

	public EnPassantMoveStrategy(Board board, YDirection yDirection)
	{
		this.board = board;
		this.yDirection = yDirection;
	}
	public MovePath GetMovePath(Move move)
	{
		var leftDiagonalCell = this.GetLeftDiagonalCell(move);
		var rightDiagonalPiece = this.GetRightDiagonalPiece(move);
		if (move.To.IsOccupied
			|| (!IsLeftMoveValid(move, leftDiagonalCell)
				&& !IsRightMoveValid(move, rightDiagonalPiece))
		)
		{
			return new InvalidMovePath(move);
		}

		return new MovePath(move, Enumerable.Empty<Coordinate>(), this);
	}

	private Cell GetRightDiagonalPiece(Move move)
	{
		return this.board.GetCell(move.From.X + 1, this.yDirection.GetYCoordinate(move.From.Y));
	}

	private Cell GetLeftDiagonalCell(Move move)
	{
		return this.board.GetCell(move.From.X - 1, this.yDirection.GetYCoordinate(move.From.Y));
	}

	private bool IsLeftMoveValid(Move move, Cell leftDiagonalCell)
	{
		var leftNeighbourCell = this.GetLeftNeighbourCell(move.From);
		return move.To.Equals(leftDiagonalCell)
			&& this.IsLeftCellValid(move.From)
			&& leftNeighbourCell.Piece.IsFirstMove
			&& Math.Abs(leftNeighbourCell.Piece.PreviousCell.Y - leftNeighbourCell.Y) == 2;
	}

	private bool IsLeftCellValid(Cell fromCell)
	{
		var leftNeighbourCell = this.GetLeftNeighbourCell(fromCell);
		return IsEnPassant(fromCell, leftNeighbourCell);
	}

	private Cell GetLeftNeighbourCell(Cell fromCell)
	{
		return this.board.GetCell(fromCell.X - 1, fromCell.Y);
	}

	private bool IsRightMoveValid(Move move, Cell rightDiagonalPiece)
	{
		var rightNeighbourCell = this.GetRightNeighbourCell(move.From);
		return move.To.Equals(rightDiagonalPiece)
			&& this.IsRightCellValid(move.From)
			&& rightNeighbourCell.Piece.IsFirstMove
			&& Math.Abs(rightNeighbourCell.Piece.PreviousCell.Y - rightNeighbourCell.Y) == 2;
	}

	private bool IsRightCellValid(Cell fromCell)
	{
		var rightNeighbourCell = this.GetRightNeighbourCell(fromCell);
		return IsEnPassant(fromCell, rightNeighbourCell);
	}

	private static bool IsEnPassant(Cell fromCell, Cell neighbourCell)
	{
		return neighbourCell.IsOccupied
			&& !neighbourCell.Piece.HasSameColor(fromCell.Piece)
			&& neighbourCell.Piece.IsOfType(typeof(Pawn));
	}

	private Cell GetRightNeighbourCell(Cell fromCell)
	{
		return this.board.GetCell(fromCell.X + 1, fromCell.Y);
	}
}
