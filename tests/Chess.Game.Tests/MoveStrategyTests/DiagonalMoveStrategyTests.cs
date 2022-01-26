using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class DiagonalMoveStrategyTests
{
	[TestCaseSource(typeof(DiagonalMoveStrategyDataCollection), nameof(DiagonalMoveStrategyDataCollection.TestCases))]
	public IEnumerable<Coordinate> ShouldFindCoordinatesCorrectly(Move fromTo)
	{
		return new DiagonalMoveStrategy().GetMovePath(fromTo);
	}

	public class DiagonalMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(5, 5)), CellTestHelper.Create(new Coordinate(5, 5))))
					.SetName("Move to same cell")
					.Returns(Enumerable.Empty<Coordinate>());

				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(5, 5))))
					.SetName("Move up-right 1 step diagonally")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(6, 6))))
					.SetName("Move up-right 2 steps diagonally")
					.Returns(new [] { new Coordinate(5,5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(7, 7))))
					.SetName("Move up-right to the edge diagonally")
					.Returns(new [] { new Coordinate(5,5), new Coordinate(6,6) });

				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(3, 5))))
					.SetName("Move up-left 1 step diagonally")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(2, 6))))
					.SetName("Move up-left 2 steps diagonally")
					.Returns(new [] { new Coordinate(3,5) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(1, 7))))
					.SetName("Move up-left to the edge diagonally")
					.Returns(new [] { new Coordinate(3,5), new Coordinate(2,6) });


				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(5, 3))))
					.SetName("Move down-right 1 step diagonally")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(6, 2))))
					.SetName("Move down-right 2 steps diagonally")
					.Returns(new [] { new Coordinate(5,3) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(7, 1))))
					.SetName("Move down-right to the edge diagonally")
					.Returns(new [] { new Coordinate(5,3), new Coordinate(6,2) });

				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(3, 3))))
					.SetName("Move down-left 1 step diagonally")
					.Returns(Enumerable.Empty<Coordinate>());
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(2, 2))))
					.SetName("Move down-left 2 steps diagonally")
					.Returns(new [] { new Coordinate(3,3) });
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(4, 4)), CellTestHelper.Create(new Coordinate(1, 1))))
					.SetName("Move down-left to the edge diagonally")
					.Returns(new [] { new Coordinate(3,3), new Coordinate(2,2) });
			}
		}
	}
}
