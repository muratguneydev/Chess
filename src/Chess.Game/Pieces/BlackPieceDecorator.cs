namespace Chess.Game;

public class BlackPieceDecorator : BoardPieceDecorator
{
	public BlackPieceDecorator(Piece originalPiece, Session session, Board board, Cell initialCell)
		: base(originalPiece, session, board, initialCell)
	{
	}

	public override Color Color => Color.Black;
}
