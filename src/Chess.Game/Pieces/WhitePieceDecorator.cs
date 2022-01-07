namespace Chess.Game;

public class WhitePieceDecorator : BoardPieceDecorator
{
	public WhitePieceDecorator(Piece originalPiece, Board board, CellHistory cellHistory)
		: base(originalPiece, board, cellHistory)
	{
	}

	public override Color Color => Color.White;
}
