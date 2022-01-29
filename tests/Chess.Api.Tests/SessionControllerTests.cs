using System.Text.Json;
using Chess.Api.Controllers;
using Chess.Api.DTO;
using Chess.Api.Requests;
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
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionPost.json");

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
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionGet.json");

		Assert.AreEqual(expectedDTOString, getResultDTOString);
	}

	[Test]
	public async Task ShouldRegisterCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await controller.Post();
		var registerResultSessionDTO = await controller.Register(new RegisterRequest(new SessionIdRequest(postResultSessionDTO.Id.Value), "WhitePlayer123", "BlackPlayer123"));

		var registerResultDTOString = JsonSerializer.Serialize(registerResultSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionRegister.json");

		Assert.AreEqual(expectedDTOString, registerResultDTOString);
	}

	[Test]
	public async Task ShouldSetReadyCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await controller.Post();
		await controller.Register(new RegisterRequest(new SessionIdRequest(postResultSessionDTO.Id.Value), "WhitePlayer123", "BlackPlayer123"));
		var setReadySessionDTO = await controller.Ready(new ReadyRequest(new SessionIdRequest(postResultSessionDTO.Id.Value)));

		var setReadyResultDTOString = JsonSerializer.Serialize(setReadySessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionReady.json");

		Assert.AreEqual(expectedDTOString, setReadyResultDTOString);
	}

	[Test]
	public async Task ShouldMoveCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await controller.Post();
		await controller.Register(new RegisterRequest(new SessionIdRequest(postResultSessionDTO.Id.Value), "WhitePlayer123", "BlackPlayer123"));
		await controller.Ready(new ReadyRequest(new SessionIdRequest(postResultSessionDTO.Id.Value)));
		var moveSessionDTO = await controller.Move(new MoveRequest(new SessionIdRequest(postResultSessionDTO.Id.Value),
			new CellRequest(1, 1), new CellRequest(1, 3)));

		var setReadyResultDTOString = JsonSerializer.Serialize(moveSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionMove.json");

		Assert.AreEqual(expectedDTOString, setReadyResultDTOString);
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
		return new TestSessionIdDTOFactory(new SessionId(Guid.Parse("5b0fcca9-d48c-47d7-ad4c-dc4ad232b204")));
	}
}
