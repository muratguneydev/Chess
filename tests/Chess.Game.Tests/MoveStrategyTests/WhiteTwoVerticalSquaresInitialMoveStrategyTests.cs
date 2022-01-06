using System.Collections;
using System.Collections.Generic;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class WhiteTwoVerticalSquaresInitialMoveStrategyTests
{
	[TestCaseSource(typeof(WhiteTwoVerticalSquaresInitialMoveStrategyDataCollection), nameof(WhiteTwoVerticalSquaresInitialMoveStrategyDataCollection.TestCases))]
	public IEnumerable<Coordinate> ShouldFindCoordinatesCorrectly(Move fromTo)
	{
		return new WhiteTwoVerticalSquaresInitialMoveStrategy(new VerticalMoveStrategy()).GetMovePath(fromTo).CoordinatesInPath;
	}

	private class WhiteTwoVerticalSquaresInitialMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(0, 1)), new Cell(new Coordinate(0, 3))))
					.SetName("a2 to a4")
					.Returns(new[] { new Coordinate(0, 2) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(1, 1)), new Cell(new Coordinate(1, 3))))
					.SetName("b2 to b4")
					.Returns(new[] { new Coordinate(1, 2) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(2, 1)), new Cell(new Coordinate(2, 3))))
					.SetName("c2 to c4")
					.Returns(new[] { new Coordinate(2, 2) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(3, 1)), new Cell(new Coordinate(3, 3))))
					.SetName("d2 to d4")
					.Returns(new[] { new Coordinate(3, 2) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(4, 1)), new Cell(new Coordinate(4, 3))))
					.SetName("e2 to e4")
					.Returns(new[] { new Coordinate(4, 2) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(5, 1)), new Cell(new Coordinate(5, 3))))
					.SetName("f2 to f4")
					.Returns(new[] { new Coordinate(5, 2) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(6, 1)), new Cell(new Coordinate(6, 3))))
					.SetName("g2 to g4")
					.Returns(new[] { new Coordinate(6, 2) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(new Cell(new Coordinate(7, 1)), new Cell(new Coordinate(7, 3))))
					.SetName("h2 to h4")
					.Returns(new[] { new Coordinate(7, 2) });
			}
		}
	}
}
