namespace Chess.Game.Tests.Helpers;

public static class PlayerTestHelper
{
	public static WhitePlayer CreateWhitePlayer(IClock? clock = null, string name = "White Player")
	{
		clock = clock ?? ClockTestHelper.Create();
		return new WhitePlayer(clock, name);
	}

	public static BlackPlayer CreateBlackPlayer(IClock? clock = null, string name = "Black Player")
	{
		clock = clock ?? ClockTestHelper.Create();
		return new BlackPlayer(clock, name);
	}
}
