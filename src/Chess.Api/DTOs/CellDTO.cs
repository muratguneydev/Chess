namespace Chess.Api.DTO;

public record CellDTO
{
	public CellDTO(int x, int y, PieceDTO piece)
	{
		this.X = x;
		this.Y = y;
		this.Piece = piece;
	}

	public CellDTO(int x, int y)
		: this(x, y, new EmptyPieceDTO())
	{
		
	}

	public int X { get; }
	public int Y { get; }

	public char Row => this.ConvertYToChar();
	public char Column => this.ConvertXToChar();
	public PieceDTO Piece { get; }

	private char ConvertYToChar()
	{
		return (char)(this.Y+48+1);
	}

	private char ConvertXToChar()
	{
		return (char)(this.X+97);
	}
}
