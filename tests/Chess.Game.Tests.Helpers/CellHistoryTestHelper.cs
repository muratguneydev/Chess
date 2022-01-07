namespace Chess.Game.Tests.Helpers;

public static class CellHistoryTestHelper
{
	public static CellHistory Create(Board? board = null)
	{
		board = board ?? BoardTestHelper.Create();
		return new CellHistory(board);
	}
}