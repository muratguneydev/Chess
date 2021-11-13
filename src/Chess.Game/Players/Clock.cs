using System.Diagnostics;

namespace Chess.Game;
public class Clock : IClock
{
	private readonly ITimer timer;
	private readonly Stopwatch stopwatch = new Stopwatch();

	public Clock(ITimer timer)
	{
		this.timer = timer;
	}

	public void Start()
	{
		this.timer.Start();
		this.stopwatch.Start();
		this.Ticking = true;
	}

	public void Stop()
	{
		this.timer.Stop();
		this.stopwatch.Stop();
		this.Ticking = false;
	}

	public void Dispose()
	{
		this.timer.Dispose();
	}

	public bool Ticking { get; private set; }

	public TimeSpan ElapsedTime => this.stopwatch.Elapsed;
}
