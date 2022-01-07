namespace Chess.Game.Tests.Helpers;

public static class WhitePieceDecoratorTestHelper
{
	public static WhitePieceDecorator Create(Piece? originalPiece = null,
		Board? board = null, CellHistory? cellHistory = null)
	{
		originalPiece = originalPiece ?? new Rook();
		board = board ?? BoardTestHelper.Create();
		cellHistory = cellHistory ?? CellHistoryTestHelper.Create();

		return new WhitePieceDecorator(originalPiece, board, cellHistory);
	}
}
