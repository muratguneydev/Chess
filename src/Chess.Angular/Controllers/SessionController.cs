using Microsoft.AspNetCore.Mvc;

namespace Chess.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly ILogger<SessionController> logger;

    public SessionController(ILogger<SessionController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        return "";
    }
}