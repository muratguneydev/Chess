using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class WhiteTwoVerticalSquaresInitialInvalidMoveStrategyTests
{
	[TestCaseSource(typeof(WhiteTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection), nameof(WhiteTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection.TestCases))]
	public void ShouldDetectInvalidMove(Move fromTo)
	{
		var movePath = new WhiteTwoVerticalSquaresInitialMoveStrategy(new VerticalMoveStrategy()).GetMovePath(fromTo);

		CellTestHelper.AssertIsNotValidMove(movePath);
	}

	private class WhiteTwoVerticalSquaresInitialInvalidMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(0, 3)), new Cell(new Coordinate(0, 5))))
					.SetName("a4 to a6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(1, 3)), new Cell(new Coordinate(1, 5))))
					.SetName("b4 to b6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(2, 3)), new Cell(new Coordinate(2, 5))))
					.SetName("c4 to c6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(3, 3)), new Cell(new Coordinate(3, 5))))
					.SetName("d4 to d6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(4, 3)), new Cell(new Coordinate(4, 5))))
					.SetName("e4 to e6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(5, 3)), new Cell(new Coordinate(5, 5))))
					.SetName("f4 to f6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(6, 3)), new Cell(new Coordinate(6, 5))))
					.SetName("g4 to g6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(7, 3)), new Cell(new Coordinate(7, 5))))
					.SetName("h4 to h6");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(0, 1)), new Cell(new Coordinate(0, 0))))
					.SetName("a2 to a1");
			}
		}
	}
}
