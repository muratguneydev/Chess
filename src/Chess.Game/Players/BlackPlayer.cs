namespace Chess.Game;

public class BlackPlayer : Player
{
	public BlackPlayer(IClock clock)
		: base(Color.Black, clock)
	{
	}
}