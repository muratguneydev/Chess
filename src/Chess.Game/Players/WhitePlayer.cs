namespace Chess.Game;

public class WhitePlayer : Player
{
	public WhitePlayer(IClock clock, string name)
		: base(Color.White, clock, name)
	{
	}
}
