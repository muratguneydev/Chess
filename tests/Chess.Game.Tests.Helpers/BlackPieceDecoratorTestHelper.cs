namespace Chess.Game.Tests.Helpers;

public static class BlackPieceDecoratorTestHelper
{
	public static BlackPieceDecorator Create(Piece? originalPiece = null,
		Board? board = null, CellHistory? cellHistory = null)
	{
		originalPiece = originalPiece ?? new Rook();
		board = board ?? BoardTestHelper.Create();
		cellHistory = cellHistory ?? CellHistoryTestHelper.Create();

		return new BlackPieceDecorator(originalPiece, board, cellHistory);
	}
}
