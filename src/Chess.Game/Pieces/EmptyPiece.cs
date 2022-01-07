namespace Chess.Game;

public class EmptyPiece : Piece
{
	private static EmptyPiece emptyPiece = new EmptyPiece();
	
	private EmptyPiece()
		: base(new EmptyMoveStrategy())
	{
	}

	public static EmptyPiece Piece => emptyPiece;
}
