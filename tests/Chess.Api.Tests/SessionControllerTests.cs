using Chess.Api.Controllers;
using Chess.Api.DTO;
using Chess.Game;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Chess.Api.Tests;

public class SessionControllerTests
{
	[Test]
	public async Task ShouldPostCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var emptyLoggerFactory = new NullLoggerFactory();
		var emptyLogger = emptyLoggerFactory.CreateLogger<SessionController>();
    
		var controller = new SessionController(new PieceDTOFactory(), sessionRepositoryStub, emptyLogger);
		var resultSessionDTO = await controller.Post();
		
		var createdSession = await sessionRepositoryStub.GetAsync(resultSessionDTO.Id.ToString());

		//SessionComparer.Compare();
		Assert.IsInstanceOf<SessionStateRegistration>(createdSession.CurrentState);
		Assert.AreEqual(typeof(SessionStateRegistration).Name, resultSessionDTO.CurrentState);
	}

}
