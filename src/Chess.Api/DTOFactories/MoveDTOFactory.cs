using Chess.Api.Request;
using Chess.Game;

namespace Chess.Api;

public class MoveDTOFactory
{
	private readonly PieceDTOFactory pieceDTOFactory;

	public MoveDTOFactory(PieceDTOFactory pieceDTOFactory)
	{
		this.pieceDTOFactory = pieceDTOFactory;
	}

	public MoveDTO Get(Move move)
	{
		return new MoveDTO(
						move.From.X, move.From.Y, this.pieceDTOFactory.Get(move.From.Piece),
						move.To.X, move.To.Y, this.pieceDTOFactory.Get(move.To.Piece));
	}
}