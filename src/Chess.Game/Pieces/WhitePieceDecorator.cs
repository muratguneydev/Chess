namespace Chess.Game;

public class WhitePieceDecorator : BoardPieceDecorator
{
	public WhitePieceDecorator(Piece originalPiece, Session session, Board board)
		: base(originalPiece, session, board)
	{
	}

	public override Color Color => Color.White;
}
