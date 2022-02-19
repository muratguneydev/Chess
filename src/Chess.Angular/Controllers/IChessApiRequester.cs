using Chess.Api.Request;

namespace Chess.Angular.Controllers;

public interface IChessApiRequester
{
	Task<string> CreateSession();
	Task<string> Register(RegisterRequest registerRequest);
	Task<string> Ready(ReadyRequest readyRequest);
	Task<string> Move(MoveRequest moveRequest);
}
