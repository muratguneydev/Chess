namespace Chess.Game;

public record InvalidMove : Move
{
	private static InvalidMove invalidMove = new InvalidMove();

	public InvalidMove(Cell cellFrom, Cell cellTo)
		: base(cellFrom, cellTo)
	{
	}

	private InvalidMove()
		: base(EmptyCell.Cell, EmptyCell.Cell)
	{
		
	}

	public static InvalidMove Move => invalidMove;
}
