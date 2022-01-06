using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class CantMoveToTheCurrentCellStrategyDecoratorTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveToTheCurrentCell()
	{
		var currentCell = new Cell(new Coordinate(1,1));
		var fromToSameCell = MoveTestHelper.Create(currentCell, currentCell);
		CellTestHelper.AssertIsNotValidMove(new CantMoveToTheCurrentCellStrategyDecorator(new TestMoveStrategy()).GetMovePath(fromToSameCell));
	}
}
