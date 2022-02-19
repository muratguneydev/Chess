using Chess.Api.Request;
using Chess.Game;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReadyController : ControllerBase
{
	private readonly SessionDTOFactory sessionDTOFactory;
	private readonly ChessSessionRepository chessSessionRepository;
	private readonly ILogger<SessionController> logger;

    public ReadyController(SessionDTOFactory sessionDTOFactory,
		ChessSessionRepository chessSessionRepository, ILogger<SessionController> logger)
    {
		this.sessionDTOFactory = sessionDTOFactory;
		this.chessSessionRepository = chessSessionRepository;
		this.logger = logger;
    }

    [HttpPut]
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
}
