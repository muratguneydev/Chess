using Chess.Game;

namespace Chess.Api.DTO;

public class WhitePieceDecoratorDTO : PieceDTO
{
	private readonly PieceDTO piece;

	public WhitePieceDecoratorDTO(PieceDTO piece)
	{
		this.piece = piece;
	}

	public override string Name => this.piece.Name;

	public override Color Color => Color.White;
}
