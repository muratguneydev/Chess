using Chess.Api.Controllers;
using Chess.Api.DTO;

namespace Chess.Api.Tests;

public class TestSessionIdDTOFactory : SessionIdDTOFactory
{
	private readonly SessionId sessionIdDTOToReturn;

	public TestSessionIdDTOFactory()
	{
		this.sessionIdDTOToReturn = new SessionId(Guid.NewGuid());
	}

	public TestSessionIdDTOFactory(SessionId sessionIdDTOToReturn)
	{
		this.sessionIdDTOToReturn = sessionIdDTOToReturn;
	}
	public override SessionId Get()
	{
		return this.sessionIdDTOToReturn;
	}
}