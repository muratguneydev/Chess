namespace Chess.Game;

public class BlackPlayer : Player
{
	public BlackPlayer(IClock clock, string name)
		: base(Color.Black, clock, name)
	{
	}
}