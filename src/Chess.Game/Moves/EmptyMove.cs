namespace Chess.Game;

public class EmptyMove : Move
{
	private static EmptyMove emptyMove = new EmptyMove();
	private EmptyMove()
		: base(EmptyCell.Cell, EmptyCell.Cell)
	{
	}

	public static EmptyMove Move => emptyMove;
}