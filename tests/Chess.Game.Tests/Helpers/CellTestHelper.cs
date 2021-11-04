using NUnit.Framework;

namespace Chess.Game.Tests;

public static class CellTestHelper
{
	public static void AssertIsValidMove(FromTo fromTo)
	{
		Assert.IsTrue(fromTo.Move().IsValid);
	}

	public static void AssertIsNotValidMove(FromTo fromTo)
	{
		Assert.IsFalse(fromTo.Move().IsValid);
	}

	public static void AssertIsValidMove(MovePath movePath)
	{
		Assert.IsTrue(movePath.IsValid);
	}

	public static void AssertIsNotValidMove(MovePath movePath)
	{
		Assert.IsFalse(movePath.IsValid);
	}

	public static void AssertIsValidMove(Move move)
	{
		Assert.IsTrue(move.IsValid);
	}
}