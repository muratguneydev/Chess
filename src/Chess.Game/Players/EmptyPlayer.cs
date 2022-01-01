namespace Chess.Game;

public class EmptyPlayer : Player
{
	private static EmptyPlayer emptyPlayer = new EmptyPlayer();

	private EmptyPlayer()
		: base(Color.None, new EmptyClock(), "-")
	{
	}

	public static EmptyPlayer Player => emptyPlayer;

	public override bool IsReady => false;
}
