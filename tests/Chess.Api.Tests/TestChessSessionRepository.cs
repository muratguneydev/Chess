using Chess.Api.Controllers;
using Chess.Game;

namespace Chess.Api.Tests;

public class TestChessSessionRepository : ChessSessionRepository
{
	private Session sessionToReturn;

	public TestChessSessionRepository()
		: base(new TestContextSession(EmptySession.Session))
	{
		this.sessionToReturn = EmptySession.Session;
	}

	public override Task<Session> GetAsync(SessionId sessionId)
	{
		return Task.FromResult(this.sessionToReturn);
	}

	public override Task SetAsync(SessionId sessionId, Session session)
	{
		this.sessionToReturn = session;
		return Task.CompletedTask;
	}
}
