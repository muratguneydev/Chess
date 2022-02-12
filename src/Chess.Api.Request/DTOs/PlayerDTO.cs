namespace Chess.Api.Request;

public record PlayerDTO
{
	public PlayerDTO(SideColor color, string name, bool isReady, int elapsedSeconds)
	{
		this.Color = color;
		this.Name = name;
		this.IsReady = isReady;
		this.ElapsedSeconds = elapsedSeconds;
	}

	public SideColor Color { get; }
	public string Name { get; }
	public bool IsReady { get; }
	public int ElapsedSeconds { get; }

	//public int ElapsedSeconds => (int)this.player.ElapsedTime.TotalSeconds;
}
