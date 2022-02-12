namespace Chess.Api.Request;

public record BlackPieceDecoratorDTO : PieceDTO
{
	private readonly PieceDTO piece;

	public BlackPieceDecoratorDTO(PieceDTO piece)
	{
		this.piece = piece;
	}

	public override string Name => this.piece.Name;

	public override SideColor Color => SideColor.Black;
}
