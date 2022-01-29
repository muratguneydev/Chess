using Chess.Api.DTO;

namespace Chess.Api.Controllers;

public class SessionIdDTOFactory
{
	public virtual SessionId Get()
	{
		return new SessionId(Guid.NewGuid());
	}
}