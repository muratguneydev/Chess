namespace Chess.Game;

public abstract class Player
{
	public Player(Color color, IClock clock, string name)
	{
		this.Color = color;
		this.Clock = clock;
		this.Name = name;
	}

	public Color Color { get; }
	public IClock Clock { get; }
	public string Name { get; }
	public TimeSpan ElapsedTime => this.Clock.CurrentElapsedTime;
	public virtual bool IsReady { get; private set; }

	public void ResumePlaying()
	{
		this.Clock.Start();
	}

	public void Wait()
	{
		this.Clock.Stop();
	}

	public void SetReady()
	{
		this.IsReady = true;
	}
}
