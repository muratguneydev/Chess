namespace Chess.Game.Tests.Helpers;

public class SessionPlayersTestBuilder
{
	private readonly SessionPlayerRegistrar sessionPlayerRegistrar = SessionPlayerRegistrarTestHelper.Create();
	private readonly SessionPlayers sessionPlayers;

	public SessionPlayersTestBuilder()
	{
		this.sessionPlayers = new SessionPlayers(sessionPlayerRegistrar);	
	}

	public SessionPlayers Build()
	{
		return this.sessionPlayers;
	}

	public SessionPlayersTestBuilder WithBlackPlayer(BlackPlayer blackPlayer)
	{
		this.sessionPlayerRegistrar.RegisterBlackPlayer(blackPlayer);
		return this;
	}

	public SessionPlayersTestBuilder WithBlackPlayer(Clock clock)
	{
		this.sessionPlayerRegistrar.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer(clock));
		return this;
	}

	public SessionPlayersTestBuilder WithWhitePlayer(WhitePlayer whitePlayer)
	{
		this.sessionPlayerRegistrar.RegisterWhitePlayer(whitePlayer);
		return this;
	}

	public SessionPlayersTestBuilder WithWhitePlayer(Clock clock)
	{
		this.sessionPlayerRegistrar.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer(clock));
		return this;
	}
}
