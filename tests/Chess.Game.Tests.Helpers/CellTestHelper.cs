using NUnit.Framework;

namespace Chess.Game.Tests.Helpers;

public static class CellTestHelper
{
	public static void AssertIsValidMove(Move move)
	{
		Assert.IsTrue(move.Go().IsValid);
	}

	public static void AssertIsValidMove2(Move move)
	{
		Assert.IsTrue(move.IsValid);
	}

	public static void AssertIsNotValidMove(Move move)
	{
		Assert.IsFalse(move.Go().IsValid);
	}

	public static void AssertIsValidMove(MovePath movePath)
	{
		Assert.IsTrue(movePath.IsValid);
	}

	public static void AssertIsNotValidMove(MovePath movePath)
	{
		Assert.IsFalse(movePath.IsValid);
	}
}