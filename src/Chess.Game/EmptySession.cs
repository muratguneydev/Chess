namespace Chess.Game;

public class EmptySession : Session
{
	private static EmptySession emptySession = new EmptySession();

	private EmptySession()
		: base(new WhitePlayer(new EmptyClock(), "-"), new BlackPlayer(new EmptyClock(), "-"))
	{
	}

	public static EmptySession Session => emptySession;
}