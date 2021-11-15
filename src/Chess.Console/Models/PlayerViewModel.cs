using Chess.Game;

namespace Chess.Console;

public class PlayerViewModel
{
	private readonly Player player;

	public PlayerViewModel(Player player)
	{
		this.player = player;
	}

	public string Name => this.player.Name;

}
