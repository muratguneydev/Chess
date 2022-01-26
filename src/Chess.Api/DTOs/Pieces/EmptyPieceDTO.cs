namespace Chess.Api.DTO;

public record EmptyPieceDTO : PieceDTO
{
	public override string Name => string.Empty;
}