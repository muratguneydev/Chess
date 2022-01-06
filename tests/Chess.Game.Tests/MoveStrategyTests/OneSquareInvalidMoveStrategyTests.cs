using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class OneSquareInvalidMoveStrategyTests
{
	[TestCaseSource(typeof(OneSquareInvalidMoveStrategyDataCollection), nameof(OneSquareInvalidMoveStrategyDataCollection.TestCases))]
	public void ShouldReturnInvalidForMoreThanOneSquare(Move fromTo)
	{
		var oneSquareMoveStrategy = new OneSquareMoveStrategy(new TestMoveStrategy());

		Assert.IsFalse(oneSquareMoveStrategy.GetMovePath(fromTo).IsValid);
	}

	private class OneSquareInvalidMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 0)), CellTestHelper.Create(new Coordinate(0, 3))))
					.SetName("Move up more than 1 row");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 7)), CellTestHelper.Create(new Coordinate(0, 3))))
					.SetName("Move down more than 1 row");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 3)), CellTestHelper.Create(new Coordinate(4, 3))))
					.SetName("Move right more than 1 row");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 7)), CellTestHelper.Create(new Coordinate(0, 7))))
					.SetName("Move left more than 1 row");

				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(4, 7))))
					.SetName("Move right 1 row up more than 1 row");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(2, 0))))
					.SetName("Move right 1 row down more than 1 row");
			}
		}
	}
}