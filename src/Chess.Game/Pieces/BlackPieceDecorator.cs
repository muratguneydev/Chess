namespace Chess.Game;

public class BlackPieceDecorator : BoardPieceDecorator
{
	public BlackPieceDecorator(Piece originalPiece, Session session, Board board)
		: base(originalPiece, session, board)
	{
	}

	public override Color Color => Color.Black;
}
