using Chess.Api.DTO;
using Chess.Game;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
	private readonly PieceDTOFactory pieceDTOFactory;
	private readonly ChessSessionRepository chessSessionRepository;
	private readonly ILogger<SessionController> logger;

    public SessionController(PieceDTOFactory pieceDTOFactory, ChessSessionRepository chessSessionRepository,
		ILogger<SessionController> logger)
    {
		this.pieceDTOFactory = pieceDTOFactory;
		this.chessSessionRepository = chessSessionRepository;
		this.logger = logger;
    }

    [HttpPost]
    public async Task<SessionDTO> Post()
    {
		var session = GetNewSession();
		var sessionDTO = new SessionDTO(session, new SessionIdDTO(Guid.NewGuid()), this.pieceDTOFactory);
		await this.chessSessionRepository.SetAsync(sessionDTO.Id, session);

		return sessionDTO;
    }

	[HttpGet]
	public async Task<SessionDTO> Get(string sessionId)
	{
		var currentSession = await this.chessSessionRepository.GetAsync(sessionId);
		return new SessionDTO(currentSession, new SessionIdDTO(sessionId), this.pieceDTOFactory);
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
