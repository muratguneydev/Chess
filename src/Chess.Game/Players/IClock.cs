namespace Chess.Game;

public interface IClock
{
	TimeSpan CurrentElapsedTime { get; }
	TimeSpan PreviousElapsedTime { get; }
	DateTime StartDateTimeUtc { get; }
	bool Ticking { get; }

	void Start();
	void Stop();
}
