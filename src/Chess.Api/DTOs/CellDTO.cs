namespace Chess.Api.DTO;

public class CellDTO
{
	public CellDTO(int x, int y, PieceDTO piece)
	{
		this.X = x;
		this.Y = y;
		this.Piece = piece;
	}
	public int X { get; }
	public int Y { get; }
	public PieceDTO Piece { get; }
}
