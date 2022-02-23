using Chess.Api.Request;
using Chess.Game;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MoveController : ControllerBase
{
	private readonly SessionDTOFactory sessionDTOFactory;
	private readonly ChessSessionRepository chessSessionRepository;
	private readonly ILogger<SessionController> logger;

    public MoveController(SessionDTOFactory sessionDTOFactory,
		ChessSessionRepository chessSessionRepository, ILogger<SessionController> logger)
    {
		this.sessionDTOFactory = sessionDTOFactory;
		this.chessSessionRepository = chessSessionRepository;
		this.logger = logger;
    }

    [HttpPut]
	public async Task<SessionDTO> Move(MoveRequest moveRequest)
	{
		var sessionId = new SessionId(moveRequest.SessionId);
		var currentSession = await this.chessSessionRepository.GetAsync(sessionId);
		var move = GetMove(moveRequest, currentSession);
		
		var moveResult = currentSession.Move(move);
		await this.chessSessionRepository.SetAsync(sessionId, currentSession);
		
		var requestResult = moveResult.IsValid ? new SuccessfulRequestResult(moveRequest) : new FailedRequestResult(moveRequest) as RequestResult;
		return this.sessionDTOFactory.Get(currentSession, sessionId, requestResult);
	}

	private static Move GetMove(MoveRequest moveRequest, Session currentSession)
	{
		var from = GetCell(moveRequest.From, currentSession);
		var to = GetCell(moveRequest.To, currentSession);
		return from.GetMove(to);
	}

	private static Cell GetCell(CellRequest cellRequest, Session currentSession)
	{
		return currentSession.Board.GetCell(cellRequest.X, cellRequest.Y);
	}
}
