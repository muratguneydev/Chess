using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class OneSquareMoveStrategyTests
{
	[TestCaseSource(typeof(OneSquareMoveStrategyDataCollection), nameof(OneSquareMoveStrategyDataCollection.TestCases))]
	public void ShouldReturnValidForOneSquare(FromTo fromTo)
	{
		var oneSquareMoveStrategy = new OneSquareMoveStrategy(new TestMoveStrategy());

		Assert.IsTrue(oneSquareMoveStrategy.GetMovePath(fromTo).IsValid);
	}

	private class OneSquareMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(0, 0)), new Cell(new Coordinate(0, 1))))
					.SetName("Move up 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(0, 2)), new Cell(new Coordinate(0, 1))))
					.SetName("Move down 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 3)), new Cell(new Coordinate(4, 3))))
					.SetName("Move right 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(5, 7)), new Cell(new Coordinate(4, 7))))
					.SetName("Move left 1 row");

				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 4)), new Cell(new Coordinate(4, 5))))
					.SetName("Move right 1 row up 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 4)), new Cell(new Coordinate(4, 3))))
					.SetName("Move right 1 row down 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 4)), new Cell(new Coordinate(2, 5))))
					.SetName("Move left 1 row up 1 row");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 4)), new Cell(new Coordinate(2, 3))))
					.SetName("Move left 1 row down 1 row");
			}
		}
	}
}
