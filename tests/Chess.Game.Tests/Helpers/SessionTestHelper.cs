namespace Chess.Game.Tests;

public static class SessionTestHelper
{
	public static Session Create(WhitePlayer? playerWhite = default(WhitePlayer), BlackPlayer? playerBlack = default(BlackPlayer))
	{
		playerWhite = playerWhite ?? new WhitePlayer();
		playerBlack = playerBlack ?? new BlackPlayer();

		return new Session(playerWhite, playerBlack);
	}
}