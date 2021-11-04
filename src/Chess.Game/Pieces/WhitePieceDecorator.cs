namespace Chess.Game;

public class WhitePieceDecorator : BoardPieceDecorator
{
	public WhitePieceDecorator(Piece originalPiece, Session session, Board board, Cell initialCell)
		: base(originalPiece, session, board, initialCell)
	{
	}

	public override Color Color => Color.White;
}
