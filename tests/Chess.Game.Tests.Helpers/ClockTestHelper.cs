namespace Chess.Game.Tests.Helpers;

public static class ClockTestHelper
{
	public static Clock Create(TimerWrapper? timerWrapper = null)
	{
		timerWrapper = timerWrapper ?? new TimerWrapper();
		return new Clock(timerWrapper);
	}
}
