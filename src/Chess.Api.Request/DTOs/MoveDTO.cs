namespace Chess.Api.Request;

public record MoveDTO
{
	private readonly int fromX;
	private readonly int fromY;
	private readonly PieceDTO fromPiece;
	private readonly int toX;
	private readonly int toY;
	private readonly PieceDTO toPiece;

	public MoveDTO(int fromX, int fromY, PieceDTO fromPiece,
		int toX, int toY, PieceDTO toPiece)
	{
		this.fromX = fromX;
		this.fromY = fromY;
		this.fromPiece = fromPiece;
		this.toX = toX;
		this.toY = toY;
		this.toPiece = toPiece;
	}

	public CellDTO From => new CellDTO(this.fromX, this.fromY, this.fromPiece);
	public CellDTO To => new CellDTO(this.toX, this.toY, this.toPiece);
}
