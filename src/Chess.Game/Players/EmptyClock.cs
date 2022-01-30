namespace Chess.Game;

public class EmptyClock : Clock
{
	private static EmptyClock emptyClock = new EmptyClock();

	private EmptyClock()
		: base(new DateTimeProvider())
	{
	}

	public static EmptyClock Clock => emptyClock;
}

// public class EmptyClock : IClock
// {
// 	public int SecondsUsed => throw new NotImplementedException();

// 	public TimeSpan CurrentElapsedTime => TimeSpan.Zero;

// 	public TimeSpan PreviousElapsedTime => throw new NotImplementedException();

// 	public DateTime StartDateTimeUtc => throw new NotImplementedException();

// 	public void Start()
// 	{
		
// 	}

// 	public void Stop()
// 	{
		
// 	}

// 	public void Dispose()
// 	{
	
// 	}
// }