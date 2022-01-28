using Chess.Api.Controllers;
using Chess.Api.DTO;

namespace Chess.Api.Tests;

public class TestSessionIdDTOFactory : SessionIdDTOFactory
{
	private readonly SessionIdDTO sessionIdDTOToReturn;

	public TestSessionIdDTOFactory()
	{
		this.sessionIdDTOToReturn = new SessionIdDTO(Guid.NewGuid());
	}

	public TestSessionIdDTOFactory(SessionIdDTO sessionIdDTOToReturn)
	{
		this.sessionIdDTOToReturn = sessionIdDTOToReturn;
	}
	public override SessionIdDTO Get()
	{
		return this.sessionIdDTOToReturn;
	}
}