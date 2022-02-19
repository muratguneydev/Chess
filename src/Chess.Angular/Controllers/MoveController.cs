using Chess.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class MoveController : ControllerBase
{
	private readonly IChessApiRequester chessApiRequester;
	private readonly ILogger<SessionController> logger;

    public MoveController(IChessApiRequester chessApiRequester, ILogger<SessionController> logger)
    {
		this.chessApiRequester = chessApiRequester;
		this.logger = logger;
    }

    [HttpPut]
    public Task<string> Put(MoveRequest moveRequest)
    {
        return this.chessApiRequester.Move(moveRequest);
    }
}
