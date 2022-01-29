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

	public virtual Task SetAsync(SessionId sessionId, Session session)
	{
		var serializableSession = new SessionSerializable(
			whitePlayer: session.WhitePlayer.IsEmpty ? EmptyPlayerSerializable.PlayerSerializable : GetSerializablePlayer(session.WhitePlayer),
			blackPlayer: session.BlackPlayer.IsEmpty ? EmptyPlayerSerializable.PlayerSerializable : GetSerializablePlayer(session.BlackPlayer),
			board: new BoardSerializable(this.GetCells(session.Board.Cells)),
			currentState: new SessionStateSerializable(session.CurrentState.GetType().FullName)
		);
		return this.contextSession.SetAsync(sessionId.Value, serializableSession);
	}

	public virtual async Task<Session> GetAsync(SessionId sessionId)
    {
        var serializedSession = await this.contextSession.GetAsync<SessionSerializable>(sessionId.Value, EmptySessionSerializable.SessionSerializable);
		var whitePlayer = serializedSession.WhitePlayer.IsEmpty ? EmptyWhitePlayer.WhitePlayer : new WhitePlayer(new Clock(TimeSpan.FromSeconds(serializedSession.WhitePlayer.ElapsedTimeInSeconds)), serializedSession.WhitePlayer.Name);
		var blackPlayer = serializedSession.BlackPlayer.IsEmpty ? EmptyBlackPlayer.BlackPlayer : new BlackPlayer(new Clock(TimeSpan.FromSeconds(serializedSession.WhitePlayer.ElapsedTimeInSeconds)), serializedSession.BlackPlayer.Name);
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

	private static PlayerSerializable GetSerializablePlayer(Player player)
	{
		return new PlayerSerializable(player.Color, player.Name, (int)player.ElapsedTime.TotalSeconds);
	}
}
