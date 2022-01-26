using Chess.Game;

namespace Chess.Api.DTO;

public record PlayerDTO
{
	private readonly Player player;

	public PlayerDTO(Player player)
	{
		this.player = player;
	}

	public Color Color => this.player.Color;
	public string Name => this.player.Name;
	public bool IsReady => this.player.IsReady;
	public int ElapsedSeconds => (int)this.player.ElapsedTime.TotalSeconds;
}