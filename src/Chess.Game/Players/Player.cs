namespace Chess.Game;

public abstract class Player
{
	private readonly IClock clock;

	public Player(Color color, IClock clock, string name)
	{
		this.Color = color;
		this.clock = clock;
		this.Name = name;
	}

	public Color Color { get; }
	public string Name { get; }

	public void ResumePlaying()
	{
		this.clock.Start();
	}

	public void Wait()
	{
		this.clock.Stop();
	}
}
