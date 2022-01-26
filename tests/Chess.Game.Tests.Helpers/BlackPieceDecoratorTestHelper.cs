namespace Chess.Game.Tests.Helpers;

public static class BlackPieceDecoratorTestHelper
{
	public static BlackPieceDecorator Create(Piece? originalPiece = null,
		CellHistory? cellHistory = null)
	{
		originalPiece = originalPiece ?? new Rook();
		cellHistory = cellHistory ?? CellHistoryTestHelper.Create();

		return new BlackPieceDecorator(originalPiece, cellHistory);
	}
}
