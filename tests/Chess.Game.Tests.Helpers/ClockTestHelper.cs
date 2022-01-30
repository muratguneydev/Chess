namespace Chess.Game.Tests.Helpers;

public static class ClockTestHelper
{
	public static Clock Create(TimeSpan? previousElapsedTime = null, DateTime? startDateTime = null, bool ticking = false, DateTimeProvider? dateTimeProvider = null)
	{
		dateTimeProvider = dateTimeProvider ?? new DateTimeProvider();
		previousElapsedTime = previousElapsedTime ?? TimeSpan.Zero;
		startDateTime = startDateTime ?? dateTimeProvider.UtcNow;
		return new Clock(previousElapsedTime.Value, startDateTime.Value, ticking, dateTimeProvider);
	}
}
