namespace Chess.Game;

public class WhitePieceDecorator : BoardPieceDecorator
{
	public WhitePieceDecorator(Piece originalPiece, Session session, Board board, CellHistory cellHistory)
		: base(originalPiece, session, board, cellHistory)
	{
	}

	public override Color Color => Color.White;
}
