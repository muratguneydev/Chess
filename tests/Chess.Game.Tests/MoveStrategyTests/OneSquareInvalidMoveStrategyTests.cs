using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class OneSquareInvalidMoveStrategyTests
{
	[TestCaseSource(typeof(OneSquareInvalidMoveStrategyDataCollection), nameof(OneSquareInvalidMoveStrategyDataCollection.TestCases))]
	public void ShouldReturnInvalidForMoreThanOneSquare(FromTo fromTo)
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
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(0, 0)), new Cell(new Coordinate(0, 3))))
					.SetName("Move up more than 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(0, 7)), new Cell(new Coordinate(0, 3))))
					.SetName("Move down more than 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(0, 3)), new Cell(new Coordinate(4, 3))))
					.SetName("Move right more than 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(5, 7)), new Cell(new Coordinate(0, 7))))
					.SetName("Move left more than 1 row");

				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 3)), new Cell(new Coordinate(4, 7))))
					.SetName("Move right 1 row up more than 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 3)), new Cell(new Coordinate(2, 0))))
					.SetName("Move right 1 row down more than 1 row");
			}
		}
	}
}