namespace Chess.Game;

public interface IClock : IDisposable
{
	void Start();
	void Stop();
	TimeSpan ElapsedTime { get; }
}
