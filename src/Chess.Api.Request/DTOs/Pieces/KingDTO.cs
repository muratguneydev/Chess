namespace Chess.Api.Request;

public record KingDTO : PieceDTO
{
	public override string Name => "King";
}
