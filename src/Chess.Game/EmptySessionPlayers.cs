namespace Chess.Game;

public class EmptySessionPlayers : SessionPlayers
{
	private static EmptySessionPlayers emptySessionPlayers = new EmptySessionPlayers();

	private EmptySessionPlayers()
		: base(new SessionPlayerRegistrar())
	{
	}

	public static EmptySessionPlayers SessionPlayers => emptySessionPlayers;
}
