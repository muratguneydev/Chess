using Chess.Game;

namespace Chess.Console.Tests;

public static class BoardViewModelTestHelper
{
	public static BoardViewModel Create(Board? board = default(Board))
	{
		board = board ?? GetBoard();//TODO: use the existing helper for this
		board.SetOpeningPosition();
		return new BoardViewModel(board);;
	}

	private static Board GetBoard()//TODO: use the existing helper for this
	{
		var whitePlayer = new WhitePlayer();
		var blackPlayer = new BlackPlayer();
		var session = new Session(whitePlayer, blackPlayer);
		return new Board(session);
	}
}
