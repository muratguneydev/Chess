using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BlackTwoVerticalSquaresInitialInvalidMoveStrategyTests
{
	[TestCaseSource(typeof(BlackTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection), nameof(BlackTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection.TestCases))]
	public void ShouldDetectInvalidMove(Move fromTo)
	{
		var movePath = new BlackTwoVerticalSquaresInitialMoveStrategy(new VerticalMoveStrategy()).GetMovePath(fromTo);

		MoveTestHelper.AssertIsNotValidMove(movePath);
	}

	private class BlackTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 5)), CellTestHelper.Create(new Coordinate(0, 3))))
					.SetName("a6 to a4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(1, 5)), CellTestHelper.Create(new Coordinate(1, 3))))
					.SetName("b6 to b4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(2, 5)), CellTestHelper.Create(new Coordinate(2, 3))))
					.SetName("c6 to c4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 5)), CellTestHelper.Create(new Coordinate(3, 3))))
					.SetName("d6 to d4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 5)), CellTestHelper.Create(new Coordinate(4, 3))))
					.SetName("e6 to e4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 5)), CellTestHelper.Create(new Coordinate(5, 3))))
					.SetName("f6 to f4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(6, 5)), CellTestHelper.Create(new Coordinate(6, 3))))
					.SetName("g6 to g4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(7, 5)), CellTestHelper.Create(new Coordinate(7, 3))))
					.SetName("h6 to h4");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 6)), CellTestHelper.Create(new Coordinate(0, 7))))
					.SetName("a7 to a8");
			}
		}
	}
}