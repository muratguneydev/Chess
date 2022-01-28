namespace Chess.Game.Tests.Helpers;

public static class ClockTestHelper
{
	public static Clock Create(TimeSpan? timeSpan = null)
	{
		timeSpan = timeSpan ?? TimeSpan.Zero;
		return new Clock(timeSpan.Value);
	}
}
