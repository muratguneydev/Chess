using Chess.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
	private readonly IChessApiRequester chessApiRequester;
	private readonly ILogger<SessionController> logger;

    public RegisterController(IChessApiRequester chessApiRequester, ILogger<SessionController> logger)
    {
		this.chessApiRequester = chessApiRequester;
		this.logger = logger;
    }

    [HttpPut]
    public Task<string> Put(RegisterRequest registerRequest)
    {
        return this.chessApiRequester.Register(registerRequest);
    }
}
