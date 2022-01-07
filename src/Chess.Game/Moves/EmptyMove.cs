namespace Chess.Game;

// public record EmptyMove : Move
// {
// 	private static EmptyMove emptyMove = new EmptyMove();
// 	private EmptyMove()
// 		: base(EmptyCell.Cell, EmptyCell.Cell)
// 	{
// 	}

// 	public static EmptyMove Move => emptyMove;
// }

public record EmptyMove : Move
{
	public EmptyMove(Board board)
		: base(board.EmptyCell, board.EmptyCell)
	{
	}
}