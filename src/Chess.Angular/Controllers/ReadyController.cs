using Chess.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class ReadyController : ControllerBase
{
	private readonly IChessApiRequester chessApiRequester;
	private readonly ILogger<SessionController> logger;

    public ReadyController(IChessApiRequester chessApiRequester, ILogger<SessionController> logger)
    {
		this.chessApiRequester = chessApiRequester;
		this.logger = logger;
    }

    [HttpPut]
    public Task<string> Put(ReadyRequest readyRequest)
    {
        return this.chessApiRequester.Ready(readyRequest);
    }
}