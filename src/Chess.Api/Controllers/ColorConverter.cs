using Chess.Api.Request;
using Chess.Game;

namespace Chess.Api.Controllers;

public static class ColorConverter
{
	public static SideColor GetSideColor(Color color)
	{
		switch (color)
		{
			case Color.White:
				return SideColor.White;
			case Color.Black:
				return SideColor.Black;
			default:
				return SideColor.None;
		}
	}
}