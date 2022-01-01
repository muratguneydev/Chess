namespace Chess.Game;

public class WhitePlayer : Player
{
	public WhitePlayer(IClock clock, string name)
		: base(Color.White, clock, name)
	{
	}

	public bool IsEmpty => this is EmptyWhitePlayer;
}

public class EmptyWhitePlayer : WhitePlayer
{
	private static EmptyWhitePlayer emptyWhitePlayer = new EmptyWhitePlayer();

	private EmptyWhitePlayer()
		: base(new EmptyClock(), EmptyPlayer.Player.Name)
	{
	}

	public static EmptyWhitePlayer WhitePlayer => emptyWhitePlayer;
	public override bool IsReady => false;
}
