namespace Chess.Game.Tests.Helpers;

public static class BoardTestHelper
{
	public static Board Create()
	{
		return new Board();
	}

	public static Move InitializeBoardWithFromCell(Func<Board, Move> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = Create();
		var fromTo = fromToGetter(board);
		
		fromTo.From.SetPiece(WhitePieceDecoratorTestHelper.Create(piece));
		return fromTo;
	}

	public static Move InitializeBoardWithFromCell(Func<Board, Move> fromToGetter, Func<Board,Piece> getPiece)
	{
		var session = SessionTestHelper.Create();
		var board = Create();
		var fromTo = fromToGetter(board);
		
		fromTo.From.SetPiece(WhitePieceDecoratorTestHelper.Create(getPiece(board)));
		return fromTo;
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellWhitePiece(Func<Board, Move> getMove, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = Create();
		var move = getMove(board);
		
		move.From.SetPiece(WhitePieceDecoratorTestHelper.Create(piece));
		return new MoveWithBoardAndSession(move, board, session);
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellWhitePiece(Func<Board, Move> getMove, Func<Board, Piece> getPiece)
	{
		var session = SessionTestHelper.Create();
		var board = Create();
		var move = getMove(board);
		
		move.From.SetPiece(WhitePieceDecoratorTestHelper.Create(getPiece(board)));
		return new MoveWithBoardAndSession(move, board, session);
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellBlackPiece(Func<Board, Move> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		
		var board = Create();
		
		var fromDummyCell = CellTestHelper.Create(new Coordinate(3, 3));
		var toDummyCell = CellTestHelper.Create(new Coordinate(4, 3));
		fromDummyCell.SetPiece(WhitePieceDecoratorTestHelper.Create(new Rook()));
		session.Move(MoveTestHelper.Create(fromDummyCell, toDummyCell));
		
		var fromTo = fromToGetter(board);
		
		fromTo.From.SetPiece(BlackPieceDecoratorTestHelper.Create(piece));
		return new MoveWithBoardAndSession(fromTo, board, session);
	}

	public static MoveWithBoardAndSession GetInitializedBoardWithFromCellBlackPiece(Func<Board, Move> fromToGetter, Func<Board,Piece> getPiece)
	{
		var session = SessionTestHelper.Create();
		
		var board = Create();
		
		var fromDummyCell = CellTestHelper.Create(new Coordinate(3, 3));
		var toDummyCell = CellTestHelper.Create(new Coordinate(4, 3));
		fromDummyCell.SetPiece(WhitePieceDecoratorTestHelper.Create(new Rook()));
		session.Move(MoveTestHelper.Create(fromDummyCell, toDummyCell));
		
		var fromTo = fromToGetter(board);
		
		fromTo.From.SetPiece(BlackPieceDecoratorTestHelper.Create(getPiece(board)));
		return new MoveWithBoardAndSession(fromTo, board, session);
	}
}
