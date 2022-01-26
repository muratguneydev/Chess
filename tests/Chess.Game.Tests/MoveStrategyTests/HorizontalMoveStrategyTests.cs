using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class HorizontalMoveStrategyTests
{
	[TestCaseSource(typeof(HorizontalMoveStrategyDataCollection), nameof(HorizontalMoveStrategyDataCollection.TestCases))]
	public IEnumerable<Coordinate> ShouldFindCoordinatesCorrectly(Move fromTo)
	{
		return new HorizontalMoveStrategy().GetMovePath(fromTo);
	}

	public class HorizontalMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 5)), CellTestHelper.Create(new Coordinate(7, 7))))
					.SetName("Move to non horizontal cell")
					.Returns(Enumerable.Empty<Coordinate>());
				
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(0, 0)), CellTestHelper.Create(new Coordinate(1, 0))))
					.SetName("Move right 1 row")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 4)), CellTestHelper.Create(new Coordinate(7, 4))))
					.SetName("Move to the right from row 4 column 5 to row 4 column 7")
					.Returns(new[] {
						new Coordinate(6, 4)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(2, 7)), CellTestHelper.Create(new Coordinate(6, 7))))
					.SetName("Move to the right from row 7 column 2 to row 7 column 6")
					.Returns(new[] {
						new Coordinate(3, 7), new Coordinate(4, 7), new Coordinate(5, 7)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(2, 7)), CellTestHelper.Create(new Coordinate(7, 7))))
					.SetName("Move to the right edge from row 7 column 2 to row 7 column 7")
					.Returns(new[] {
						new Coordinate(3, 7), new Coordinate(4, 7), new Coordinate(5, 7), new Coordinate(6, 7)
					});
				
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(1, 0)), CellTestHelper.Create(new Coordinate(0, 0))))
					.SetName("Move left 1 row")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(7, 4)), CellTestHelper.Create(new Coordinate(5, 4))))
					.SetName("Move to the left from row 4 column 7 to row 4 column 5")
					.Returns(new[] {
						new Coordinate(6, 4)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(6, 7)), CellTestHelper.Create(new Coordinate(2, 7))))
					.SetName("Move to the left from row 7 column 6 to row 7 column 2")
					.Returns(new[] {
						new Coordinate(3, 7), new Coordinate(4, 7), new Coordinate(5, 7)
					});
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(6, 7)), CellTestHelper.Create(new Coordinate(0, 7))))
					.SetName("Move to the left edge from row 7 column 6 to row 7 column 0")
					.Returns(new[] {
						new Coordinate(1, 7), new Coordinate(2, 7), new Coordinate(3, 7), new Coordinate(4, 7), new Coordinate(5, 7)
					});
			}
		}
	}
}
