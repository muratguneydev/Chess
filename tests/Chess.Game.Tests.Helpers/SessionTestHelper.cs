namespace Chess.Game.Tests.Helpers;

public static class SessionTestHelper
{
	public static Session Create(WhitePlayer? playerWhite = default(WhitePlayer), BlackPlayer? playerBlack = default(BlackPlayer))
	{
		playerWhite = playerWhite ?? new WhitePlayer(new Clock(new TimerWrapper()));
		playerBlack = playerBlack ?? new BlackPlayer(new Clock(new TimerWrapper()));

		return new Session(playerWhite, playerBlack);
	}
}