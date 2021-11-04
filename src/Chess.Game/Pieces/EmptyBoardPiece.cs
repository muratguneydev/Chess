namespace Chess.Game;

public class EmptyBoardPiece : BoardPieceDecorator
{
	private static readonly Session dummySession = new Session(new WhitePlayer(), new BlackPlayer());
	private static EmptyBoardPiece emptyBoardPiece = new EmptyBoardPiece();

	private EmptyBoardPiece()
		: base(EmptyPiece.Piece, dummySession, new Board(dummySession), EmptyCell.Cell) //TODO:Do we need the real board, session?
	{
	}

	public static EmptyBoardPiece Piece => emptyBoardPiece;

	public override Color Color => Color.None;
}