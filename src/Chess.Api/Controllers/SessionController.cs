using Chess.Api.DTO;
using Chess.Api.Requests;
using Chess.Game;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
	private readonly PieceDTOFactory pieceDTOFactory;
	private readonly ChessSessionRepository chessSessionRepository;
	private readonly SessionIdDTOFactory sessionIdDTOFactory;
	private readonly ILogger<SessionController> logger;

    public SessionController(PieceDTOFactory pieceDTOFactory, ChessSessionRepository chessSessionRepository,
		SessionIdDTOFactory sessionIdDTOFactory, ILogger<SessionController> logger)
    {
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
		var sessionDTO = new SessionDTO(session, sessionId, this.pieceDTOFactory,
			new SuccessfulRequestResult(new CreateSessionRequest(new SessionId(sessionId.Value))));
		await this.chessSessionRepository.SetAsync(sessionDTO.Id, session);

		return sessionDTO;
    }

	[HttpGet]
	public async Task<SessionDTO> Get(string sessionId)
	{
		var currentSession = await this.chessSessionRepository.GetAsync(sessionId);
		return new SessionDTO(currentSession, new SessionIdDTO(sessionId), this.pieceDTOFactory,
			new SuccessfulRequestResult(new GetSessionRequest(new SessionId(sessionId))));
	}

	// [HttpPut]
	// public async Task<SessionDTO> Register(RegisterRequest registerRequest)
	// {
	// 	var currentSession = await this.chessSessionRepository.GetAsync(registerRequest.SessionId.Value);
	// 	//currentSession.RegisterBlackPlayer(new BlackPlayer())
		
	// 	var move = new Move(GetCell(registerRequest.From, currentSession), GetCell(registerRequest.To, currentSession));
	// 	var moveResult = currentSession.Move(move);
		
	// 	var requestResult = moveResult.IsValid ? new SuccessfulRequestResult(registerRequest) : new FailedRequestResult(registerRequest) as RequestResult;

	// 	return new SessionDTO(currentSession, new SessionIdDTO(registerRequest.SessionId.Value), this.pieceDTOFactory, requestResult);
	// }

	[HttpPut]
	public async Task<SessionDTO> Move(MoveRequest moveRequest)
	{
		var currentSession = await this.chessSessionRepository.GetAsync(moveRequest.SessionId.Value);
		var move = new Move(GetCell(moveRequest.From, currentSession), GetCell(moveRequest.To, currentSession));
		var moveResult = currentSession.Move(move);
		
		var requestResult = moveResult.IsValid ? new SuccessfulRequestResult(moveRequest) : new FailedRequestResult(moveRequest) as RequestResult;

		return new SessionDTO(currentSession, new SessionIdDTO(moveRequest.SessionId.Value), this.pieceDTOFactory, requestResult);
	}

	private static Cell GetCell(CellRequest cellRequest, Session currentSession)
	{
		return currentSession.Board.GetCell(cellRequest.X, cellRequest.Y);// new Cell(GetCoordinateFromCellRequest(cellRequest), currentSession.Board);
	}

	// private static Coordinate GetCoordinateFromCellRequest(CellRequest cellRequest)
	// {
	// 	return new Coordinate(cellRequest.X, cellRequest.Y);
	// }

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
