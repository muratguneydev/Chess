using Chess.Game;

namespace Chess.Api.DTO;

public class PlayerDTO
{
	private readonly Player player;

	public PlayerDTO(Player player)
	{
		// this.Color = player.Color;
		// this.Name = player.Name;
		// this.IsReady = player.IsReady;
		// this.ElapsedSeconds = (int)player.ElapsedTime.TotalSeconds;
		this.player = player;
	}

	public Color Color => this.player.Color;
	public string Name => this.player.Name;
	public bool IsReady => this.player.IsReady;
	public int ElapsedSeconds => (int)this.player.ElapsedTime.TotalSeconds;
}