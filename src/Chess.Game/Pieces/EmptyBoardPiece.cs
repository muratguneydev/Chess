namespace Chess.Game;

// public class EmptyBoardPiece : BoardPieceDecorator
// {
// 	//private static readonly Session dummySession = EmptySession.Session;
// 	//private static EmptyBoardPiece emptyBoardPiece = new EmptyBoardPiece();

// 	public EmptyBoardPiece(Session session, Board board)
// 		: base(EmptyPiece.Piece, session, board, new CellHistory()) //TODO:Do we need the real board, session?
// 	{
// 	}

// 	//public static EmptyBoardPiece Piece => emptyBoardPiece;

// 	public override Color Color => Color.None;
// }

public class EmptyBoardPiece : BoardPieceDecorator
{
	private static readonly Session dummySession = EmptySession.Session;
	private static EmptyBoardPiece emptyBoardPiece = new EmptyBoardPiece();

	private EmptyBoardPiece()
		: base(EmptyPiece.Piece, dummySession, new Board(dummySession), new CellHistory()) //TODO:Do we need the real board, session?
	{
	}

	public static EmptyBoardPiece Piece => emptyBoardPiece;

	public override Color Color => Color.None;
}