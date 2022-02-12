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

		return sessionDTO;
    }

	[HttpGet]
	public async Task<SessionDTO> Get(string sessionId)
	{
		var currentSession = await this.chessSessionRepository.GetAsync(new SessionId(sessionId));
		return this.sessionDTOFactory.Get(currentSession, new SessionId(sessionId),
			new SuccessfulRequestResult(new GetSessionRequest(new SessionIdRequest(sessionId))));
	}

	[HttpPut("register")]
	public async Task<SessionDTO> Register(RegisterRequest registerRequest)
	{
		var sessionId = new SessionId(registerRequest.SessionId);
		var currentSession = await this.chessSessionRepository.GetAsync(sessionId);
		currentSession.RegisterWhitePlayer(new WhitePlayer(new Clock(new DateTimeProvider()), registerRequest.WhitePlayerName));
		currentSession.RegisterBlackPlayer(new BlackPlayer(new Clock(new DateTimeProvider()), registerRequest.BlackPlayerName));
		await this.chessSessionRepository.SetAsync(sessionId, currentSession);
		var requestResult = new SuccessfulRequestResult(registerRequest);

		return this.sessionDTOFactory.Get(currentSession, sessionId, requestResult);
	}

	[HttpPut("ready")]
	public async Task<SessionDTO> Ready(ReadyRequest readyRequest)
	{
		var sessionId = new SessionId(readyRequest.SessionId);
		var currentSession = await this.chessSessionRepository.GetAsync(sessionId);
		currentSession.SetWhitePlayerReady();
		currentSession.SetBlackPlayerReady();
		await this.chessSessionRepository.SetAsync(sessionId, currentSession);
		var requestResult = new SuccessfulRequestResult(readyRequest);

		return this.sessionDTOFactory.Get(currentSession, sessionId, requestResult);
	}

	[HttpPut("move")]
	public async Task<SessionDTO> Move(MoveRequest moveRequest)
	{
		var sessionId = new SessionId(moveRequest.SessionId);
		var currentSession = await this.chessSessionRepository.GetAsync(sessionId);
		var move = new Move(GetCell(moveRequest.From, currentSession), GetCell(moveRequest.To, currentSession));
		var moveResult = currentSession.Move(move);
		
		var requestResult = moveResult.IsValid ? new SuccessfulRequestResult(moveRequest) : new FailedRequestResult(moveRequest) as RequestResult;

		return this.sessionDTOFactory.Get(currentSession, sessionId, requestResult);
	}

	private static Cell GetCell(CellRequest cellRequest, Session currentSession)
	{
		return currentSession.Board.GetCell(cellRequest.X, cellRequest.Y);
	}

	private static Session GetNewSession()
	{
		var board = new Board();
		board.SetOpeningPosition();

		var sessionPlayerRegistrar = new SessionPlayerRegistrar();
		sessionPlayerRegistrar.AddPlayersRegisteredEventCallback(sessionPlayerRegistrar => {});
		
		var sessionPlayers = new SessionPlayers(sessionPlayerRegistrar);
		sessionPlayers.AddPlayersReadyEventCallback(sessionPlayers => {});
		
		return new Session(sessionPlayers, sessionPlayerRegistrar, new SessionStateMachine(), board);
	}

	
}
