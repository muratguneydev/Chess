using Chess.Game;
using static Chess.Console.TestClass;

namespace Chess.Console.Tests;

public static class BoardViewModelTestHelper
{
	public static BoardViewModel Create(Board? board = default(Board))
	{
		board = board ?? BoardTestHelper.Create();
		board.SetOpeningPosition();
		return new BoardViewModel(board);;
	}
}
