using Microsoft.AspNetCore.Mvc;

namespace Chess.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
	private readonly IChessApiRequester chessApiRequester;
	private readonly ILogger<SessionController> logger;

    public SessionController(IChessApiRequester chessApiRequester, ILogger<SessionController> logger)
    {
		this.chessApiRequester = chessApiRequester;
		this.logger = logger;
    }

    [HttpPost]
    public Task<string> CreateSession()
    {
        return this.chessApiRequester.CreateSession();
    }
}
