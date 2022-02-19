using Chess.Api.Request;
using Chess.Game;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
	private readonly SessionDTOFactory sessionDTOFactory;
	private readonly ChessSessionRepository chessSessionRepository;
	private readonly ILogger<SessionController> logger;

    public RegisterController(SessionDTOFactory sessionDTOFactory,
		ChessSessionRepository chessSessionRepository, ILogger<SessionController> logger)
    {
		this.sessionDTOFactory = sessionDTOFactory;
		this.chessSessionRepository = chessSessionRepository;
		this.logger = logger;
    }

    [HttpPut]
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
}
