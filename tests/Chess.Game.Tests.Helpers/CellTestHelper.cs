using NUnit.Framework;

namespace Chess.Game.Tests.Helpers;

public static class CellTestHelper
{
	public static Cell Create(int x = 0, int y = 0, Board? board = null)
	{
		board = board ?? BoardTestHelper.Create();
		return new Cell(x, y, board);
	}

	public static Cell Create(Coordinate coordinate, Board? board = null)
	{
		board = board ?? BoardTestHelper.Create();
		return new Cell(coordinate, board);
	}
}