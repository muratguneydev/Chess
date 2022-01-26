namespace Chess.Game;

public record BlackPieceDecorator : BoardPieceDecorator
{
	public BlackPieceDecorator(Piece originalPiece, CellHistory cellHistory)
		: base(originalPiece, cellHistory)
	{
	}

	public override Color Color => Color.Black;
}
