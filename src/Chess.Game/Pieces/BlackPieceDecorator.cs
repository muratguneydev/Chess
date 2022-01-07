namespace Chess.Game;

public class BlackPieceDecorator : BoardPieceDecorator
{
	public BlackPieceDecorator(Piece originalPiece, Board board, CellHistory cellHistory)
		: base(originalPiece, board, cellHistory)
	{
	}

	public override Color Color => Color.Black;
}
