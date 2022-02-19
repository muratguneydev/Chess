using System.Text;
using Chess.Game;
using Microsoft.Extensions.Caching.Distributed;

namespace Chess.Api.Controllers;

public class ChessSessionRepository
{
	private readonly IDistributedCache cache;

	//private readonly ContextSession contextSession;

	public ChessSessionRepository(IDistributedCache cache)
	//ContextSession contextSession)
	{
		this.cache = cache;
		//this.contextSession = contextSession;
	}

	public virtual async Task SetAsync(SessionId sessionId, Session session)
	{
		var serializableSession = new SessionSerializable(
			whitePlayer: session.WhitePlayer.IsEmpty ? EmptyPlayerSerializable.PlayerSerializable : GetSerializablePlayer(session.WhitePlayer),
			blackPlayer: session.BlackPlayer.IsEmpty ? EmptyPlayerSerializable.PlayerSerializable : GetSerializablePlayer(session.BlackPlayer),
			board: new BoardSerializable(this.GetCells(session.Board.Cells)),
			currentState: new SessionStateSerializable(session.CurrentState.GetType().FullName),
			moveHistory: session.MoveHistory.Select(move => new MoveSerializable(move))
		);
		//return this.contextSession.SetAsync(sessionId.Value, serializableSession);
		var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(300));
		await this.cache.SetAsync(sessionId.Value, Encoding.UTF8.GetBytes(await serializableSession.Serialize()), options);
	}

	public virtual async Task<Session> GetAsync(SessionId sessionId)
	{
		//var sessionSerializable = await this.contextSession.GetAsync<SessionSerializable>(sessionId.Value, EmptySessionSerializable.SessionSerializable);
		var serializedSession =  await this.cache.GetStringAsync(sessionId.Value);
		var sessionSerializable = SessionSerializable.DeSerialize(serializedSession);

		var whitePlayer = sessionSerializable.WhitePlayer.IsEmpty ? EmptyWhitePlayer.WhitePlayer : new WhitePlayer(sessionSerializable.WhitePlayer.Clock.Convert(), sessionSerializable.WhitePlayer.Name);
		var blackPlayer = sessionSerializable.BlackPlayer.IsEmpty ? EmptyBlackPlayer.BlackPlayer : new BlackPlayer(sessionSerializable.BlackPlayer.Clock.Convert(), sessionSerializable.BlackPlayer.Name);
		var registrar = new SessionPlayerRegistrar(whitePlayer, blackPlayer);
		var board = sessionSerializable.Board.Convert();
		var moveHistory = new MoveHistory(board, sessionSerializable.MoveHistory.Select(moveSerializable => moveSerializable.Convert(board)));
		return new Session(new SessionPlayers(registrar), registrar, new SessionStateMachine(sessionSerializable.CurrentState.Convert()),
			board, moveHistory);
	}

	private IEnumerable<CellSerializable> GetCells(Cell[,] cells)
	{
		for (var x = 0; x <= cells.GetUpperBound(0); x++)
		{
			for (var y = 0; y <= cells.GetUpperBound(1); y++)
			{
				var piece = cells[x, y].Piece;
				yield return new CellSerializable(x, y, new PieceSerializable(piece.OriginalPieceType.FullName, piece.Color, piece.CellHistory));
			}
		}
	}

	private static PlayerSerializable GetSerializablePlayer(Player player)
	{
		return new PlayerSerializable(player.Color, player.Name, ClockSerializable.Create(player.Clock));
	}
}

