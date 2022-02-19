using Chess.Api.Request;
using Chess.Game;

namespace Chess.Api;

public class PlayerDTOFactory
{
	public PlayerDTO Get(Player player)
	{
		return new PlayerDTO(ColorConverter.GetSideColor(player.Color), player.Name, player.IsReady, (int)player.ElapsedTime.TotalSeconds);
	}

	
}
