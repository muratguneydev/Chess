namespace Chess.Game.Tests.Helpers;
using System.Timers;
public static class SessionTestHelper
{
	public static Session Create(WhitePlayer? playerWhite = default(WhitePlayer), BlackPlayer? playerBlack = default(BlackPlayer))
	{
		playerWhite = playerWhite ?? PlayerTestHelper.CreateWhitePlayer();
		playerBlack = playerBlack ?? PlayerTestHelper.CreateBlackPlayer();

		return new Session(playerWhite, playerBlack);
	}
}
