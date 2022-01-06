using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class VerticalMoveStrategyTests
{
	[TestCaseSource(typeof(VerticalMoveStrategyDataCollection), nameof(VerticalMoveStrategyDataCollection.TestCases))]
	public IEnumerable<Coordinate> ShouldFindCoordinatesCorrectly(Move fromTo)
	{
		return new VerticalMoveStrategy().GetMovePath(fromTo).CoordinatesInPath;
	}

	private class VerticalMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 0)), CellTestHelper.Create(new Coordinate(0, 1))))
					.SetName("Move up 1 row")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 2)), CellTestHelper.Create(new Coordinate(5, 4))))
					.SetName("Move up from row 2 column 5 to row 4 column 5")
					.Returns(new[] {
						new Coordinate(5, 3)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(7, 2)), CellTestHelper.Create(new Coordinate(7, 6))))
					.SetName("Move up from row 2 column 7 to row 6 column 7")
					.Returns(new[] {
						new Coordinate(7, 3), new Coordinate(7, 4), new Coordinate(7, 5)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 4)), CellTestHelper.Create(new Coordinate(5, 7))))
					.SetName("Move up to the top from row 4 column 5 to row 7 column 5")
					.Returns(new[] {
						new Coordinate(5, 5), new Coordinate(5, 6)
					});
				
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(1, 0)), CellTestHelper.Create(new Coordinate(0, 0))))
					.SetName("Move down 1 row")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 7)), CellTestHelper.Create(new Coordinate(4, 5))))
					.SetName("Move down from row 7 column 4 to row 5 column 4")
					.Returns(new[] {
						new Coordinate(4, 6)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(7, 6)), CellTestHelper.Create(new Coordinate(7, 2))))
					.SetName("Move down from row 6 column 7 to row 2 column 7")
					.Returns(new[] {
						new Coordinate(7, 3), new Coordinate(7, 4), new Coordinate(7, 5)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 3)), CellTestHelper.Create(new Coordinate(4, 0))))
					.SetName("Move down to the bottom from row 3 column 4 to row 0 column 4")
					.Returns(new[] {
						new Coordinate(4, 1), new Coordinate(4, 2)
					});
			}
		}
	}
}
