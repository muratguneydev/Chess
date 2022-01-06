using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class LShapeMoveStrategyTests
{
	[TestCaseSource(typeof(LShapeMoveStrategyDataCollection), nameof(LShapeMoveStrategyDataCollection.TestCases))]
	public void ShouldFindCoordinatesCorrectly(Move fromTo)
	{
		var movePath = new LShapeMoveStrategy().GetMovePath(fromTo);

		CellTestHelper.AssertIsValidMove(movePath);
	}

	private class LShapeMoveStrategyDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(4, 5))))
					.SetName("Two up one right");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(2, 5))))
					.SetName("Two up one left");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(5, 4))))
					.SetName("One up two right");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(1, 4))))
					.SetName("One up two left");
				
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(4, 1))))
					.SetName("Two down one right");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(2, 1))))
					.SetName("Two down one left");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(5, 2))))
					.SetName("One down two right");
				yield return new MoveStrategyTestData(MoveTestHelper.Create(CellTestHelper.Create(new Coordinate(3, 3)), CellTestHelper.Create(new Coordinate(1, 2))))
					.SetName("One down two left");
			}
		}
	}
}