namespace Chess.Game.Tests.Helpers;

public static class BoardPieceDecoratorTestHelper
{
	public static bool Equals(IBoardPiece x, IBoardPiece y)
	{
		return new BoardPieceDecoratorEqualityComparer().Equals(x, y);
	}
}
