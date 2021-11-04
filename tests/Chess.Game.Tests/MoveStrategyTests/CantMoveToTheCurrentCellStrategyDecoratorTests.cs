using NUnit.Framework;

namespace Chess.Game.Tests;

public partial class CantMoveToTheCurrentCellStrategyDecoratorTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveToTheCurrentCell()
	{
		var currentCell = new Cell(new Coordinate(1,1));
		var fromToSameCell = new FromTo(currentCell, currentCell);
		CellTestHelper.AssertIsNotValidMove(new CantMoveToTheCurrentCellStrategyDecorator(new TestMoveStrategy()).GetMovePath(fromToSameCell));
	}
}
