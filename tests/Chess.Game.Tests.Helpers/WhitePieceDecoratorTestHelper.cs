namespace Chess.Game.Tests.Helpers;

public static class WhitePieceDecoratorTestHelper
{
	public static WhitePieceDecorator Create(Piece? originalPiece = null, Session? session = null,
		Board? board = null, CellHistory? cellHistory = null)
	{
		originalPiece = originalPiece ?? new Rook();
		session = session ?? SessionTestHelper.Create();
		board = board ?? BoardTestHelper.Create(session);
		cellHistory = cellHistory ?? CellHistoryTestHelper.Create();

		return new WhitePieceDecorator(originalPiece, session, board, cellHistory);
	}
}
