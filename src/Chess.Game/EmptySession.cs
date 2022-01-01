namespace Chess.Game;

public class EmptySession : Session
{
	private static EmptySession emptySession = new EmptySession();

	private EmptySession()
		: base(EmptySessionPlayers.SessionPlayers, new SessionPlayerRegistrar())
	{
	}

	public static EmptySession Session => emptySession;
}