namespace Chess.Api.Request;

public record EmptyPieceDTO : PieceDTO
{
	public override string Name => string.Empty;
}