using Chess.Api.DTO;

namespace Chess.Api.Controllers;

public class SessionIdDTOFactory
{
	public virtual SessionIdDTO Get()
	{
		return new SessionIdDTO(Guid.NewGuid());
	}
}