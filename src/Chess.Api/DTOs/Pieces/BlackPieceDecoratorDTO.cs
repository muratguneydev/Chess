using Chess.Game;

namespace Chess.Api.DTO;

public class BlackPieceDecoratorDTO : PieceDTO
{
	private readonly PieceDTO piece;

	public BlackPieceDecoratorDTO(PieceDTO piece)
	{
		this.piece = piece;
	}

	public override string Name => this.piece.Name;

	public override Color Color => Color.Black;
}
