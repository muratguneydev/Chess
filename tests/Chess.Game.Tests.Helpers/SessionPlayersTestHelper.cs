namespace Chess.Game.Tests.Helpers;

public static class SessionPlayersTestHelper
{
	public static SessionPlayers Create(Clock? whiteClock = null, Clock? blackClock = null)
	{
		whiteClock = whiteClock ?? ClockTestHelper.Create();
		blackClock = blackClock ?? ClockTestHelper.Create();
		return new SessionPlayersTestBuilder()
			.WithWhitePlayer(whiteClock)
			.WithBlackPlayer(blackClock)
			.Build();
	}

	public static SessionPlayers CreateWithoutRegister()
	{
		return new SessionPlayersTestBuilder()
			.Build();
	}
}
