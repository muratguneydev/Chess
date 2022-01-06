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
		
		fromTo.From.SetPiece(WhitePieceDecoratorTestHelper.Create(piece, session, board));
		return fromTo;
	}

	public static Move InitializeBoardWithFromCell(Func<Board, Move> fromToGetter, Func<Board,Piece> getPiece)
	{
		var session = SessionTestHelper.Create();
		var board = Create(session);
		var fromTo = fromToGetter(board);
		
		fromTo.From.SetPiece(WhitePieceDecoratorTestHelper.Create(getPiece(board), session, board));
		return fromTo;
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellWhitePiece(Func<Board, Move> getMove, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = Create(session);
		var move = getMove(board);
		
		move.From.SetPiece(WhitePieceDecoratorTestHelper.Create(piece, session, board));
		return new MoveWithBoardAndSession(move, board, session);
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellWhitePiece(Func<Board, Move> getMove, Func<Board, Piece> getPiece)
	{
		var session = SessionTestHelper.Create();
		var board = Create(session);
		var move = getMove(board);
		
		move.From.SetPiece(WhitePieceDecoratorTestHelper.Create(getPiece(board), session, board));
		return new MoveWithBoardAndSession(move, board, session);
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellBlackPiece(Func<Board, Move> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		
		var board = Create(session);
		
		var fromDummyCell = new Cell(new Coordinate(3, 3));
		var toDummyCell = new Cell(new Coordinate(4, 3));
		fromDummyCell.SetPiece(WhitePieceDecoratorTestHelper.Create(new Rook(), session, board));
		session.Move(MoveTestHelper.Create(fromDummyCell, toDummyCell));
		
		var fromTo = fromToGetter(board);
		
		fromTo.From.SetPiece(BlackPieceDecoratorTestHelper.Create(piece, session, board));
		return new MoveWithBoardAndSession(fromTo, board, session);
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellBlackPiece(Func<Board, Move> fromToGetter, Func<Board,Piece> getPiece)
	{
		var session = SessionTestHelper.Create();
		
		var board = Create(session);
		
		var fromDummyCell = new Cell(new Coordinate(3, 3));
		var toDummyCell = new Cell(new Coordinate(4, 3));
		fromDummyCell.SetPiece(WhitePieceDecoratorTestHelper.Create(new Rook(), session, board));
		session.Move(MoveTestHelper.Create(fromDummyCell, toDummyCell));
		
		var fromTo = fromToGetter(board);
		
		fromTo.From.SetPiece(BlackPieceDecoratorTestHelper.Create(getPiece(board), session, board));
		return new MoveWithBoardAndSession(fromTo, board, session);
	}
}
