using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BlackTwoVerticalSquaresInitialInvalidMoveStrategyTests
{
	[TestCaseSource(typeof(BlackTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection), nameof(BlackTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection.TestCases))]
	public void ShouldDetectInvalidMove(FromTo fromTo)
	{
		var movePath = new BlackTwoVerticalSquaresInitialMoveStrategy(new VerticalMoveStrategy()).GetMovePath(fromTo);

		CellTestHelper.AssertIsNotValidMove(movePath);
	}

	private class BlackTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(0, 5)), new Cell(new Coordinate(0, 3))))
					.SetName("a6 to a4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(1, 5)), new Cell(new Coordinate(1, 3))))
					.SetName("b6 to b4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(2, 5)), new Cell(new Coordinate(2, 3))))
					.SetName("c6 to c4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(3, 5)), new Cell(new Coordinate(3, 3))))
					.SetName("d6 to d4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(4, 5)), new Cell(new Coordinate(4, 3))))
					.SetName("e6 to e4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(5, 5)), new Cell(new Coordinate(5, 3))))
					.SetName("f6 to f4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(6, 5)), new Cell(new Coordinate(6, 3))))
					.SetName("g6 to g4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(7, 5)), new Cell(new Coordinate(7, 3))))
					.SetName("h6 to h4");
				yield return new MoveStrategyTestData(new FromTo(new Cell(new Coordinate(0, 6)), new Cell(new Coordinate(0, 7))))
					.SetName("a7 to a8");
			}
		}
	}
}