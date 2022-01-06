namespace Chess.Game.Tests.Helpers;

public static class MoveTestHelper
{
	public static Move Create(Cell? from = null, Cell? to = null)
	{
		from = from ?? CellTestHelper.Create(0, 0);
		to = to ?? CellTestHelper.Create(1, 1);
		//return from.GetMove(to);// new Move(from, to);
		return new Move(from, to);
	}

	public static Move CreateByConstructor(Cell? from = null, Cell? to = null)
	{
		from = from ?? CellTestHelper.Create(0, 0);
		to = to ?? CellTestHelper.Create(1, 1);
		return new Move(from, to);
	}
}