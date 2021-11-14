namespace Chess.Game.Tests.Helpers;

public static class BoardTestHelper
{
	public static Board Create(Session? session = null)
	{
		session = session ?? SessionTestHelper.Create();
		return new Board(session);
	}

	public static Move InitializeBoardWithFromCell(Func<Board, Move> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = Create(session);
		var fromTo = fromToGetter(board);
		
		fromTo.From.Initialize(new WhitePieceDecorator(piece, session, board, fromTo.From));
		return fromTo;
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellWhitePiece(Func<Board, Move> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = Create(session);
		var fromTo = fromToGetter(board);
		
		fromTo.From.Initialize(new WhitePieceDecorator(piece, session, board, fromTo.From));
		return new MoveWithBoardAndSession(fromTo, board, session);
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellBlackPiece(Func<Board, Move> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		
		var board = Create(session);
		
		var fromDummyCell = new Cell(new Coordinate(3, 3));
		var toDummyCell = new Cell(new Coordinate(4, 3));
		fromDummyCell.Initialize(new WhitePieceDecorator(new Rook(), session, board, fromDummyCell));
		session.Next(new Move(fromDummyCell, toDummyCell));
		
		var fromTo = fromToGetter(board);
		
		fromTo.From.Initialize(new BlackPieceDecorator(piece, session, board, fromTo.From));
		return new MoveWithBoardAndSession(fromTo, board, session);
	}
}
