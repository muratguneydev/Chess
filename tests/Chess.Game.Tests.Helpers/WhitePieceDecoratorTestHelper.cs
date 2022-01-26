namespace Chess.Game.Tests.Helpers;

public static class WhitePieceDecoratorTestHelper
{
	public static WhitePieceDecorator Create(Piece? originalPiece = null,
		CellHistory? cellHistory = null)
	{
		originalPiece = originalPiece ?? new Rook();
		cellHistory = cellHistory ?? CellHistoryTestHelper.Create();

		return new WhitePieceDecorator(originalPiece, cellHistory);
	}
}
