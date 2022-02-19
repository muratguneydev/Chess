using Chess.Api.Controllers;
using Chess.Game;

namespace Chess.Api.Tests;

public class TestChessSessionRepository : ChessSessionRepository
{
	private Session sessionToReturn;

	public TestChessSessionRepository()
		: base(new TestDistributedCache())
	{
		this.sessionToReturn = EmptySession.Session;
	}

	public override Task<Session> GetAsync(SessionId sessionId)
	{
		return Task.FromResult(this.sessionToReturn);
	}

	public override Task SetAsync(SessionId sessionId, Session session)
	{
		this.SetAsyncCallCount++;
		this.sessionToReturn = session;
		return Task.CompletedTask;
	}

	public int SetAsyncCallCount { get; private set; }
}
