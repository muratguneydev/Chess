namespace Chess.Api.Request;

public record WhitePieceDecoratorDTO : PieceDTO
{
	private readonly PieceDTO piece;

	public WhitePieceDecoratorDTO(PieceDTO piece)
	{
		this.piece = piece;
	}

	public override string Name => this.piece.Name;

	public override SideColor Color => SideColor.White;
}
