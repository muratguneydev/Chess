using Chess.Api.Request;
using Chess.Game;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
	private readonly SessionDTOFactory sessionDTOFactory;
	private readonly PieceDTOFactory pieceDTOFactory;
	private readonly ChessSessionRepository chessSessionRepository;
	private readonly SessionIdDTOFactory sessionIdDTOFactory;
	private readonly ILogger<SessionController> logger;

    public SessionController(SessionDTOFactory sessionDTOFactory, PieceDTOFactory pieceDTOFactory,
		ChessSessionRepository chessSessionRepository, SessionIdDTOFactory sessionIdDTOFactory, ILogger<SessionController> logger)
    {
		this.sessionDTOFactory = sessionDTOFactory;
		this.pieceDTOFactory = pieceDTOFactory;
		this.chessSessionRepository = chessSessionRepository;
		this.sessionIdDTOFactory = sessionIdDTOFactory;
		this.logger = logger;
    }

    [HttpPost]
    public async Task<SessionDTO> Post()
    {
		var session = GetNewSession();
		var sessionId = this.sessionIdDTOFactory.Get();
		var lastRequestResult = new SuccessfulRequestResult(new CreateSessionRequest(new SessionIdRequest(sessionId.Value)));
		var sessionDTO = this.sessionDTOFactory.Get(session, sessionId, lastRequestResult);
		await this.chessSessionRepository.SetAsync(sessionId, session);

		this.logger.LogInformation($"Created new session. {sessionId}");
		return sessionDTO;
    }

	[HttpGet]
	public async Task<SessionDTO> Get(string sessionId)
	{
		var currentSession = await this.chessSessionRepository.GetAsync(new SessionId(sessionId));
		return this.sessionDTOFactory.Get(currentSession, new SessionId(sessionId),
			new SuccessfulRequestResult(new GetSessionRequest(new SessionIdRequest(sessionId))));
	}

	private static Session GetNewSession()
	{
		var board = new Board();
		board.SetOpeningPosition();

		var sessionPlayerRegistrar = new SessionPlayerRegistrar();
		sessionPlayerRegistrar.AddPlayersRegisteredEventCallback(sessionPlayerRegistrar => {});
		
		var sessionPlayers = new SessionPlayers(sessionPlayerRegistrar);
		sessionPlayers.AddPlayersReadyEventCallback(sessionPlayers => {});
		
		return new Session(sessionPlayers, sessionPlayerRegistrar, new SessionStateMachine(), board, new MoveHistory(board));
	}

	
}
