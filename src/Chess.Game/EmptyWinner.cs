namespace Chess.Game;

public class EmptyWinner : Winner
{
	private static readonly EmptyWinner emptyWinner = new EmptyWinner();

	private EmptyWinner()
	{

	}

	public static EmptyWinner Winner => emptyWinner;
}
