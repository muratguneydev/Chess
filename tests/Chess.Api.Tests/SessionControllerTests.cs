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
		var controller = GetSessionController(sessionRepositoryStub);
		var resultSessionDTO = await controller.Post();

		var createdSession = await sessionRepositoryStub.GetAsync(resultSessionDTO.Id.Value);

		//SessionComparer.Compare();
		Assert.IsInstanceOf<SessionStateRegistration>(createdSession.CurrentState);
		Assert.AreEqual(typeof(SessionStateRegistration).Name, resultSessionDTO.CurrentState);
	}

	[Test]
	public async Task ShouldGetCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub);
		var postResultSessionDTO = await controller.Post();
		var getResultSessionDTO = await controller.Get(postResultSessionDTO.Id.Value);

		//var createdSession = await sessionRepositoryStub.GetAsync(postResultSessionDTO.Id.Value);

		//SessionComparer.Compare();
		//Assert.IsInstanceOf<SessionStateRegistration>(createdSession.CurrentState);
		//Assert.AreEqual(typeof(SessionStateRegistration).Name, resultSessionDTO.CurrentState);
	}

	

	private static SessionController GetSessionController(TestChessSessionRepository sessionRepositoryStub)
	{
		var emptyLoggerFactory = new NullLoggerFactory();
		var emptyLogger = emptyLoggerFactory.CreateLogger<SessionController>();

		var controller = new SessionController(new PieceDTOFactory(), sessionRepositoryStub, emptyLogger);
		return controller;
	}
}
