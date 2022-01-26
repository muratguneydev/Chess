namespace Chess.Game;

public record WhitePieceDecorator : BoardPieceDecorator
{
	public WhitePieceDecorator(Piece originalPiece, CellHistory cellHistory)
		: base(originalPiece, cellHistory)
	{
	}

	public override Color Color => Color.White;
}
