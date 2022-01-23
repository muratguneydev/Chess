using Chess.Game;

namespace Chess.Api.Controllers;

public class ChessSessionRepository
{
	private readonly ContextSession contextSession;

	public ChessSessionRepository(ContextSession contextSession)
	{
		this.contextSession = contextSession;
	}

	public virtual Task SetAsync(string key, Session session)
    {
		return this.contextSession.SetAsync(key, session);		
    }

	public virtual Task<Session> GetAsync(string key)
    {
        return this.contextSession.GetAsync<Session>(key, EmptySession.Session);
    }
}
