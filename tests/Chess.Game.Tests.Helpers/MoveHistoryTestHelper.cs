namespace Chess.Game.Tests.Helpers;

public static class MoveHistoryTestHelper
{
	public static MoveHistory Create(Board? board = null, IEnumerable<Move>? moves = null)
	{
		board = board ?? BoardTestHelper.Create();
		moves = moves ?? new [] { MoveTestHelper.Create() };
		
		var moveHistory = new MoveHistory(board, moves);

		return moveHistory;
	}
}