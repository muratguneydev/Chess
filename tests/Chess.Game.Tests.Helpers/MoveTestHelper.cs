using NUnit.Framework;

namespace Chess.Game.Tests.Helpers;

public static class MoveTestHelper
{
	public static Move Create(Cell? from = null, Cell? to = null)
	{
		from = from ?? CellTestHelper.Create(0, 0);
		to = to ?? CellTestHelper.Create(1, 1);
		//return from.GetMove(to);// new Move(from, to);
		return new Move(from, to);
	}

	public static Move CreateByConstructor(Cell? from = null, Cell? to = null)
	{
		from = from ?? CellTestHelper.Create(0, 0);
		to = to ?? CellTestHelper.Create(1, 1);
		return new Move(from, to);
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