using Chess.Game;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Console.Tests;

public class ConsoleMoveInputTests
{
    [TestCase(null, TestName="No input provided")]
    [TestCase("invalidinputstring", TestName="No dash")]
    [TestCase("a2-b3-d4", TestName="Only 1 dash allowed")]
	public void ShouldThrowArgumentExceptionForInvalidMoveString(string moveString)
	{
		var board = GetBoard();

		Assert.Throws<InvalidMoveStringException>(() => new ConsoleMoveInput(moveString, board));
	}

	[TestCase("z2-b3", TestName="Invalid from cell name")]
    [TestCase("a2-k3", TestName="Invalid to cell name")]
    public void ShouldThrowArgumentExceptionForInvalidCellName(string moveString)
	{
		var board = GetBoard();

		Assert.Throws<InvalidCellNameException>(() => new ConsoleMoveInput(moveString, board));
	}

	[TestCase("c8-d1", 2, 7, 3, 0)]
    public void ShouldParseFromToCellsCorrectlyFromMoveString(string moveString, int fromX, int fromY, int toX, int toY)
    {
		var board = GetBoard();

		var consoleMoveInput = new ConsoleMoveInput(moveString, board);
        Assert.AreEqual(new Coordinate(fromX, fromY), consoleMoveInput.FromTo.From.Coordinate);
        Assert.AreEqual(new Coordinate(toX, toY), consoleMoveInput.FromTo.To.Coordinate);
    }

	private static BoardViewModel GetBoard()
	{
		return new BoardViewModel(BoardTestHelper.Create());
	}
}
