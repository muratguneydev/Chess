namespace Chess.Game;

public class EmptyCell : Cell
{
	private static EmptyCell emptyCell = new EmptyCell();

	private EmptyCell()
		: base(EmptyCoordinate.Coordinate)
	{
	}

	public static EmptyCell Cell => emptyCell;

	public override Move Move(Cell destinationCell)
	{
		return new InvalidMove(this, destinationCell);
	}
}