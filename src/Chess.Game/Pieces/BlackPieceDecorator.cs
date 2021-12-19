namespace Chess.Game;

public class BlackPieceDecorator : BoardPieceDecorator
{
	public BlackPieceDecorator(Piece originalPiece, Session session, Board board, CellHistory cellHistory)
		: base(originalPiece, session, board, cellHistory)
	{
	}

	public override Color Color => Color.Black;
}
