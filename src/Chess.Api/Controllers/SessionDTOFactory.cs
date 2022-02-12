using Chess.Api.Request;
using Chess.Game;

namespace Chess.Api.Controllers;

public class SessionDTOFactory
{
	private readonly BoardDTOFactory boardDTOFactory;
	private readonly PlayerDTOFactory playerDTOFactory;
	private readonly PieceDTOFactory pieceDTOFactory;
	private readonly MoveDTOFactory moveDTOFactory;

	public SessionDTOFactory(BoardDTOFactory boardDTOFactory, PlayerDTOFactory playerDTOFactory,
		PieceDTOFactory pieceDTOFactory, MoveDTOFactory moveDTOFactory)
	{
		this.boardDTOFactory = boardDTOFactory;
		this.playerDTOFactory = playerDTOFactory;
		this.pieceDTOFactory = pieceDTOFactory;
		this.moveDTOFactory = moveDTOFactory;
	}

	public SessionDTO Get(Session session, SessionId id, RequestResult lastRequestResult)
	{
		return new SessionDTO(id: new SessionIdDTO(id.Value), board: this.boardDTOFactory.Get(session.Board),
			whitePlayer: this.playerDTOFactory.Get(session.WhitePlayer), blackPlayer: this.playerDTOFactory.Get(session.BlackPlayer),
			currentPlayer: this.playerDTOFactory.Get(session.CurrentPlayer), waitingPlayer: this.playerDTOFactory.Get(session.WaitingPlayer),
			playerTurnColor: ColorConverter.GetSideColor(session.PlayTurn),
			moveHistory: session.MoveHistory.Select(move => this.moveDTOFactory.Get(move)),
			currentState: session.CurrentState.GetType().Name, lastRequestResult: lastRequestResult);
	}

	
}