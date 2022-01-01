namespace Chess.Game.Tests.Helpers;

public static class SessionTestHelper
{
	public static Session Create(WhitePlayer? playerWhite = default(WhitePlayer), BlackPlayer? playerBlack = default(BlackPlayer))
	{
		playerWhite = playerWhite ?? PlayerTestHelper.CreateWhitePlayer();
		playerBlack = playerBlack ?? PlayerTestHelper.CreateBlackPlayer();

		var sessionPlayers = new SessionPlayersTestBuilder()
			.WithBlackPlayer(playerBlack)
			.WithWhitePlayer(playerWhite)
			.Build();

		return new Session(sessionPlayers, SessionPlayerRegistrarTestHelper.Create());
	}
}
