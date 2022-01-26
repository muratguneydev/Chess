using Chess.Api.DTO;
using Chess.Game;

namespace Chess.Api.Controllers;

public class ChessSessionRepository
{
	private readonly ContextSession contextSession;

	public ChessSessionRepository(ContextSession contextSession)
	{
		this.contextSession = contextSession;
	}

	public virtual Task SetAsync(SessionIdDTO sessionIdDTO, Session session)
    {
		var serializableSession = new SessionSerializable(
			whitePlayer: session.WhitePlayer.IsEmpty ? EmptyPlayerSerializable.PlayerSerializable : new PlayerSerializable(session.WhitePlayer.Color, session.WhitePlayer.Name),
			blackPlayer: session.BlackPlayer.IsEmpty ? EmptyPlayerSerializable.PlayerSerializable : new PlayerSerializable(session.BlackPlayer.Color, session.BlackPlayer.Name),
			board: new BoardSerializable(this.GetCells(session.Board.Cells)),
			currentState: new SessionStateSerializable(session.CurrentState.GetType().FullName)
		);
		return this.contextSession.SetAsync(sessionIdDTO.Value, serializableSession);		
    }

	public virtual async Task<Session> GetAsync(string key)
    {
        var serializedSession = await this.contextSession.GetAsync<SessionSerializable>(key, EmptySessionSerializable.SessionSerializable);
		var whitePlayer = serializedSession.WhitePlayer.IsEmpty ? EmptyWhitePlayer.WhitePlayer : new WhitePlayer(new Clock(new TimerWrapper()), serializedSession.WhitePlayer.Name);
		var blackPlayer = serializedSession.BlackPlayer.IsEmpty ? EmptyBlackPlayer.BlackPlayer : new BlackPlayer(new Clock(new TimerWrapper()), serializedSession.BlackPlayer.Name);
		var registrar = new SessionPlayerRegistrar(whitePlayer, blackPlayer);
		return new Session(new SessionPlayers(registrar), registrar, new SessionStateMachine(serializedSession.CurrentState.Convert()),
			new Board(serializedSession.Board.GetCells()));
    }

	private IEnumerable<CellSerializable> GetCells(Cell[,] cells)
	{
		for (var x=0;x <= cells.GetUpperBound(0);x++)
		{
			for (var y=0;y <= cells.GetUpperBound(1);y++)
			{
				var piece = cells[x, y].Piece;
				yield return new CellSerializable(x, y, new PieceSerializable(piece.OriginalPieceType.FullName, piece.Color, piece.CellHistory));
			}
		}
	}

	// private static LinkedList<CellSerializable> GetCellHistory(IBoardPiece piece)
	// {
	// 	return new LinkedList<CellSerializable>(piece.CellHistory
	// 		.Select(cell => new CellSerializable(cell.X, cell.Y, EmptyPieceSerializable.PieceSerializable)));
	// }
}
