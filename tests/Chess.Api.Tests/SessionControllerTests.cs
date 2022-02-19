using System.Text.Json;
using System.Text.Json.Serialization;
using Chess.Api.Controllers;
using Chess.Api.Request;
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

		var resultDTOString = Serialize(resultSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionCreateResult.json");

		Assert.AreEqual(expectedDTOString, resultDTOString);
		//var createdSession = await sessionRepositoryStub.GetAsync(resultSessionDTO.Id.Value);

		ShouldSaveSession(sessionRepositoryStub, 1);
	}

	[Test]
	public async Task ShouldGetCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await controller.Post();
		var getResultSessionDTO = await controller.Get(postResultSessionDTO.Id.Value);

		var getResultDTOString = Serialize(getResultSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionGetResult.json");

		Assert.AreEqual(expectedDTOString, getResultDTOString);
	}

	[Test]
	public async Task ShouldRegisterCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var sessionController = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await sessionController.Post();

		var registerController = GetRegisterController(sessionRepositoryStub);
		var registerResultSessionDTO = await registerController.Register(new RegisterRequest(new SessionIdRequest(postResultSessionDTO.Id.Value), "WhitePlayer123", "BlackPlayer123"));

		var registerResultDTOString = Serialize(registerResultSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionRegisterResult.json");

		Assert.AreEqual(expectedDTOString, registerResultDTOString);
		ShouldSaveSession(sessionRepositoryStub, 2);
	}

	[Test]
	public async Task ShouldSetReadyCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await controller.Post();
		
		var registerController = GetRegisterController(sessionRepositoryStub);
		await registerController.Register(new RegisterRequest(new SessionIdRequest(postResultSessionDTO.Id.Value), "WhitePlayer123", "BlackPlayer123"));
		
		var readyController = GetReadyController(sessionRepositoryStub);
		var setReadySessionDTO = await readyController.Ready(new ReadyRequest(new SessionIdRequest(postResultSessionDTO.Id.Value)));

		var setReadyResultDTOString = Serialize(setReadySessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionReadyResult.json");

		Assert.AreEqual(expectedDTOString, setReadyResultDTOString);
		ShouldSaveSession(sessionRepositoryStub, 3);
	}

	[Test]
	public async Task ShouldMoveCorrectly()
	{
		var sessionRepositoryStub = new TestChessSessionRepository();
		var controller = GetSessionController(sessionRepositoryStub, GetSessionDTOFactoryStub());
		var postResultSessionDTO = await controller.Post();
		
		
		var registerController = GetRegisterController(sessionRepositoryStub);
		await registerController.Register(new RegisterRequest(new SessionIdRequest(postResultSessionDTO.Id.Value), "WhitePlayer123", "BlackPlayer123"));
		
		var readyController = GetReadyController(sessionRepositoryStub);
		await readyController.Ready(new ReadyRequest(new SessionIdRequest(postResultSessionDTO.Id.Value)));
		
		var moveController = GetMoveController(sessionRepositoryStub);
		var moveSessionDTO = await moveController.Move(new MoveRequest(new SessionIdRequest(postResultSessionDTO.Id.Value),
			new CellRequest(1, 1), new CellRequest(1, 3)));

		var moveResultDTOString = Serialize(moveSessionDTO);
		var expectedDTOString = await File.ReadAllTextAsync("../../../ResultJson/SessionMoveResult.json");

		Assert.AreEqual(expectedDTOString, moveResultDTOString);
		ShouldSaveSession(sessionRepositoryStub, 4);
	}

	private static SessionController GetSessionController(TestChessSessionRepository sessionRepositoryStub,
		SessionIdDTOFactory? sessionIdDTOFactory = null)
	{
		sessionIdDTOFactory = sessionIdDTOFactory ?? new TestSessionIdDTOFactory();
		var emptyLoggerFactory = new NullLoggerFactory();
		var emptyLogger = emptyLoggerFactory.CreateLogger<SessionController>();

		var pieceDTOFactory = new PieceDTOFactory();
		var controller = new SessionController(new SessionDTOFactory(new BoardDTOFactory(pieceDTOFactory),
				new PlayerDTOFactory(), new PieceDTOFactory(), new MoveDTOFactory(pieceDTOFactory)),
			pieceDTOFactory, sessionRepositoryStub, sessionIdDTOFactory, emptyLogger);
		return controller;
	}

	private static RegisterController GetRegisterController(TestChessSessionRepository sessionRepositoryStub)
	{
		var emptyLoggerFactory = new NullLoggerFactory();
		var emptyLogger = emptyLoggerFactory.CreateLogger<SessionController>();

		var pieceDTOFactory = new PieceDTOFactory();
		var controller = new RegisterController(new SessionDTOFactory(new BoardDTOFactory(pieceDTOFactory),
				new PlayerDTOFactory(), new PieceDTOFactory(), new MoveDTOFactory(pieceDTOFactory)),
			sessionRepositoryStub, emptyLogger);
		return controller;
	}

	private static ReadyController GetReadyController(TestChessSessionRepository sessionRepositoryStub)
	{
		var emptyLoggerFactory = new NullLoggerFactory();
		var emptyLogger = emptyLoggerFactory.CreateLogger<SessionController>();

		var pieceDTOFactory = new PieceDTOFactory();
		var controller = new ReadyController(new SessionDTOFactory(new BoardDTOFactory(pieceDTOFactory),
				new PlayerDTOFactory(), new PieceDTOFactory(), new MoveDTOFactory(pieceDTOFactory)),
			sessionRepositoryStub, emptyLogger);
		return controller;
	}

	private static MoveController GetMoveController(TestChessSessionRepository sessionRepositoryStub)
	{
		var emptyLoggerFactory = new NullLoggerFactory();
		var emptyLogger = emptyLoggerFactory.CreateLogger<SessionController>();

		var pieceDTOFactory = new PieceDTOFactory();
		var controller = new MoveController(new SessionDTOFactory(new BoardDTOFactory(pieceDTOFactory),
				new PlayerDTOFactory(), new PieceDTOFactory(), new MoveDTOFactory(pieceDTOFactory)),
			sessionRepositoryStub, emptyLogger);
		return controller;
	}

	private static TestSessionIdDTOFactory GetSessionDTOFactoryStub()
	{
		return new TestSessionIdDTOFactory(new SessionId(Guid.Parse("5b0fcca9-d48c-47d7-ad4c-dc4ad232b204")));
	}

	private static string Serialize<T>(T dto)
	{
		JsonSerializerOptions options = new()
            {
                Converters = { new JsonStringEnumConverter() }
            };

		return JsonSerializer.Serialize(dto, options);
	}

	private static void ShouldSaveSession(TestChessSessionRepository sessionRepositoryStub, int expectedNumberOfTimes)
	{
		Assert.AreEqual(sessionRepositoryStub.SetAsyncCallCount, expectedNumberOfTimes);
	}
}
