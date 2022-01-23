namespace Chess.Game;

public record WhitePieceDecorator : BoardPieceDecorator
{
	public WhitePieceDecorator(Piece originalPiece, Board board, CellHistory cellHistory)
		: base(originalPiece, board, cellHistory)
	{
	}

	public override Color Color => Color.White;
}
