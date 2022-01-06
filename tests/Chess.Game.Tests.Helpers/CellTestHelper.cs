using NUnit.Framework;

namespace Chess.Game.Tests.Helpers;

public static class CellTestHelper
{
	public static Cell Create(int x = 0, int y = 0)
	{
		return new Cell(x, y);
	}

	public static Cell Create(Coordinate coordinate)
	{
		return new Cell(coordinate);
	}

	public static void AssertIsValidMove(Move move)
	{
		Assert.IsTrue(GetValidatedMove(move).IsValid);
	}

	public static void AssertIsNotValidMove(Move move)
	{
		//TODO:Temporary. Currently lots of tests make use of the invalidated move by using Move constructor rather than cell.GetMove.
		Assert.IsFalse(GetValidatedMove(move).IsValid);
	}

	public static void AssertIsValidMove(MovePath movePath)
	{
		Assert.IsTrue(movePath.IsValid);
	}

	public static void AssertIsNotValidMove(MovePath movePath)
	{
		Assert.IsFalse(movePath.IsValid);
	}

	private static Move GetValidatedMove(Move move)
	{
		return move.From.GetMove(move.To);
	}
}