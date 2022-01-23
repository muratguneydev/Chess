namespace Chess.Game;

public record EmptyCell : Cell
{
	public EmptyCell(Board board)
		: base(EmptyCoordinate.Coordinate, board)
	{
	}

	public override Move GetMove(Cell destinationCell)
	{
		return new InvalidMove(this, destinationCell);
	}
}