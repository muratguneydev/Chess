using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class CantMoveToTheCurrentCellStrategyDecoratorTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveToTheCurrentCell()
	{
		var currentCell = CellTestHelper.Create(new Coordinate(1,1));
		var fromToSameCell = MoveTestHelper.Create(currentCell, currentCell);
		MoveTestHelper.AssertIsNotValidMove(new CantMoveToTheCurrentCellStrategyDecorator(new TestMoveStrategy()).GetMovePath(fromToSameCell));
	}
}
