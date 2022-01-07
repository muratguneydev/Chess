namespace Chess.Game;

// public class EmptyCell : Cell
// {
// 	private static EmptyCell emptyCell = new EmptyCell();

// 	private EmptyCell()
// 		: base(EmptyCoordinate.Coordinate)
// 	{
// 	}

// 	public static EmptyCell Cell => emptyCell;

// 	public override Move GetMove(Cell destinationCell)
// 	{
// 		return new InvalidMove(this, destinationCell);
// 	}
// }

public class EmptyCell : Cell
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