using System.Text.Json;
using Chess.Api.Controllers;
using Chess.Api.DTO;
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
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var resultSessionDTO = await controller.Post();

		var resultDTOString = JsonSerializer.Serialize(resultSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../SessionPost.json");

		Assert.AreEqual(expectedDTOString, resultDTOString);
		//var createdSession = await sessionRepositoryStub.GetAsync(resultSessionDTO.Id.Value);

		// var moveRequest = new MoveRequest(new SessionId("5b0fcca9-d48c-47d7-ad4c-dc4ad232b204"), new CellRequest(1,1), new CellRequest(2,2));
		// var a = JsonSerializer.Serialize(moveRequest);
	}

	[Test]
	public async Task ShouldGetCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await controller.Post();
		var getResultSessionDTO = await controller.Get(postResultSessionDTO.Id.Value);

		var getResultDTOString = JsonSerializer.Serialize(getResultSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../SessionGet.json");

		Assert.AreEqual(expectedDTOString, getResultDTOString);
	}

	private static SessionController GetSessionController(TestChessSessionRepository sessionRepositoryStub,
		SessionIdDTOFactory? sessionIdDTOFactory = null)
	{
		sessionIdDTOFactory = sessionIdDTOFactory ?? new TestSessionIdDTOFactory();
		var emptyLoggerFactory = new NullLoggerFactory();
		var emptyLogger = emptyLoggerFactory.CreateLogger<SessionController>();

		var controller = new SessionController(new PieceDTOFactory(), sessionRepositoryStub, sessionIdDTOFactory, emptyLogger);
		return controller;
	}

	private static TestSessionIdDTOFactory GetSessionDTOFactoryStub()
	{
		return new TestSessionIdDTOFactory(new SessionIdDTO(Guid.Parse("5b0fcca9-d48c-47d7-ad4c-dc4ad232b204")));
	}
}
