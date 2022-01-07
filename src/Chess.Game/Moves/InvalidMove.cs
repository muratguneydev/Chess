namespace Chess.Game;

public record InvalidMove : Move
{
	//private static InvalidMove invalidMove = new InvalidMove();

	public InvalidMove(Cell cellFrom, Cell cellTo)
		: base(cellFrom, cellTo)
	{
	}

	public InvalidMove(Move move)
		: base(move.From, move.To)
	{
	}

	// private InvalidMove()
	// 	: base(EmptyCell.Cell, EmptyCell.Cell)
	// {
		
	// }

	// public static InvalidMove Move => invalidMove;
}
