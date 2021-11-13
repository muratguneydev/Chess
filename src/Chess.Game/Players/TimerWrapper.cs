namespace Chess.Game;

using System.Timers;//This has to be after the namespace declaration to find this namespace before the hierarchical search find System.Threading.Timer

public class TimerWrapper : ITimer
{
	private Timer timer;

	public TimerWrapper()
	{
		this.timer = new Timer();
		this.timer.Enabled = true;
	}

	public void Start()
	{
		this.timer.Start();
	}

	public void Stop()
	{
		this.timer.Stop();
	}

	//https://blogs.msmvps.com/peterritchie/2013/01/20/the-dispose-pattern-as-an-anti-pattern/
	public void Dispose()
	{
		this.timer.Dispose();
	}
}