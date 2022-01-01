namespace Chess.Game;

public class BlackPlayer : Player
{
	public BlackPlayer(IClock clock, string name)
		: base(Color.Black, clock, name)
	{
	}

	public bool IsEmpty => this is EmptyBlackPlayer;
}

public class EmptyBlackPlayer : BlackPlayer
{
	private static EmptyBlackPlayer emptyBlackPlayer = new EmptyBlackPlayer();

	private EmptyBlackPlayer()
		: base(new EmptyClock(), EmptyPlayer.Player.Name)
	{
	}

	public static EmptyBlackPlayer BlackPlayer => emptyBlackPlayer;
	public override bool IsReady => false;
}