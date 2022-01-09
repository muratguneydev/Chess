namespace Chess.Game.Tests.Helpers;

public static class BoardPieceDecoratorTestHelper
{
	public static bool Equals(IBoardPiece x, IBoardPiece y)
	{
		return x == y;
		//Note: Reference check is sufficient for now. new BoardPieceDecoratorEqualityComparer().Equals(x, y);
	}
}
