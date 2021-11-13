namespace Chess.Game;

public class EmptyClock : IClock
{
	public int SecondsUsed => throw new NotImplementedException();

	public TimeSpan ElapsedTime => TimeSpan.MinValue;

	public void Start()
	{
		
	}

	public void Stop()
	{
		
	}

	public void Dispose()
	{
	
	}
}