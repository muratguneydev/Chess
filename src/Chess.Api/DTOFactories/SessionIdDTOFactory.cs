namespace Chess.Api;

public class SessionIdDTOFactory
{
	public virtual SessionId Get()
	{
		return new SessionId(Guid.NewGuid());
	}
}