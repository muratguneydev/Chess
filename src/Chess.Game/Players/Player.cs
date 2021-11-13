namespace Chess.Game;

public abstract class Player
{
	private readonly IClock clock;

	public Player(Color color, IClock clock)
	{
		Color = color;
		this.clock = clock;
	}

	public Color Color { get; }

	public void ResumePlaying()
	{
		this.clock.Start();
	}

	public void Wait()
	{
		this.clock.Stop();
	}
}
