namespace Chess.Game.Tests;

internal record TestPiece : BoardPieceDecorator
{
	private readonly Color color;

	public TestPiece()
		: base(new Rook(), new CellHistory())
	{
		this.color = Color.White;
	}

	public TestPiece(Color color)
		: base(new Rook(), new CellHistory())
	{
		this.color = color;
	}

	public TestPiece(Piece piece, Color color)
		: base(piece, new CellHistory())
	{
		this.color = color;
	}

	public TestPiece(Piece piece, Color color, Board board)
		: base(piece, new CellHistory())
	{
		this.color = color;
	}

	public override Color Color => this.color;
}
