using Chess.Game;

namespace Chess.Api.DTO;

public class PieceDTOFactory
{
	private readonly Dictionary<Type, Func<PieceDTO>> pieceFactory = new Dictionary<Type, Func<PieceDTO>>
	{
		{ typeof(EmptyPiece), () => new EmptyPieceDTO() },
		{ typeof(Pawn), () => new PawnDTO() },
		{ typeof(Rook), () => new RookDTO() },
		{ typeof(Knight), () => new KnightDTO() },
		{ typeof(Bishop), () => new BishopDTO() },
		{ typeof(Queen), () => new QueenDTO() },
		{ typeof(King), () => new KingDTO() }
	};

	public virtual PieceDTO Get(IBoardPiece piece)
	{
		//return this.pieceFactory[typeof(T)]();
		return pieceFactory
			.Single(pieceTypeFactory => piece.IsOfType(pieceTypeFactory.Key))
			.Value();
	}
}
