namespace Chess.Game;

public interface IClock
{
	void Start();
	void Stop();
	TimeSpan ElapsedTime { get; }
}
