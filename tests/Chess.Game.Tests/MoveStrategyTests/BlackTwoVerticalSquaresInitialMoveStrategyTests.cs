using System.Collections;
using System.Collections.Generic;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BlackTwoVerticalSquaresInitialMoveStrategyTests
{
	[TestCaseSource(typeof(BlackTwoVerticalSquaresInitialMoveStrategyDataCollection), nameof(BlackTwoVerticalSquaresInitialMoveStrategyDataCollection.TestCases))]
	public IEnumerable<Coordinate> ShouldFindCoordinatesCorrectly(Move fromTo)
	{
		return new BlackTwoVerticalSquaresInitialMoveStrategy(new VerticalMoveStrategy()).GetMovePath(fromTo).CoordinatesInPath;
	}

	private class BlackTwoVerticalSquaresInitialMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 6)), CellTestHelper.Create(new Coordinate(0, 4))))
					.SetName("a7 to a5")
					.Returns(new[] { new Coordinate(0, 5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(1, 6)), CellTestHelper.Create(new Coordinate(1, 4))))
					.SetName("b7 to b5")
					.Returns(new[] { new Coordinate(1, 5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(2, 6)), CellTestHelper.Create(new Coordinate(2, 4))))
					.SetName("c7 to c5")
					.Returns(new[] { new Coordinate(2, 5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 6)), CellTestHelper.Create(new Coordinate(3, 4))))
					.SetName("d7 to d5")
					.Returns(new[] { new Coordinate(3, 5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 6)), CellTestHelper.Create(new Coordinate(4, 4))))
					.SetName("e7 to e5")
					.Returns(new[] { new Coordinate(4, 5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 6)), CellTestHelper.Create(new Coordinate(5, 4))))
					.SetName("f7 to f5")
					.Returns(new[] { new Coordinate(5, 5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(6, 6)), CellTestHelper.Create(new Coordinate(6, 4))))
					.SetName("g7 to g5")
					.Returns(new[] { new Coordinate(6, 5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(7, 6)), CellTestHelper.Create(new Coordinate(7, 4))))
					.SetName("h7 to h5")
					.Returns(new[] { new Coordinate(7, 5) });
			}
		}
	}
}
