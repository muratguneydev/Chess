namespace Chess.Game;

public record EmptySession : Session
{
	private static EmptySession emptySession = new EmptySession();

	private EmptySession()
		: base(EmptySessionPlayers.SessionPlayers, new SessionPlayerRegistrar(), new SessionStateMachine(), new Board())
	{
	}

	public static EmptySession Session => emptySession;
}