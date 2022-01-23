using Chess.Api.DTO;
using Chess.Game;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardController : ControllerBase
{
	private readonly PieceDTOFactory pieceDTOFactory;
	private readonly ILogger<BoardController> logger;

    public BoardController(PieceDTOFactory pieceDTOFactory, ILogger<BoardController> logger)
    {
		this.pieceDTOFactory = pieceDTOFactory;
		this.logger = logger;
    }

    [HttpGet]
    public BoardDTO Get()
    {
        var board = new Board();
		board.SetOpeningPosition();
		return new BoardDTO(board, this.pieceDTOFactory);
    }
}
