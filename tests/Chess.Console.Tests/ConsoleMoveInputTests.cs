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
	[TestCase("c8-d7", 2, 7, 3, 6)]
    public void ShouldParseFromToCellsCorrectlyFromMoveString(string moveString, int fromX, int fromY, int toX, int toY)
    {
		var board = GetBoard();

		var consoleMoveInput = new ConsoleMoveInput(moveString, board);
        Assert.AreEqual(new Coordinate(fromX, fromY), consoleMoveInput.Move.From.Coordinate);
        Assert.AreEqual(new Coordinate(toX, toY), consoleMoveInput.Move.To.Coordinate);
    }

	[Test]
    public void ShouldParseFromToCellsCorrectlyFromMoveString2()
    {
		var board = GetBoard();

		var moveString = "d7-c8";
		var fromX = 3;
		var fromY = 6;
		var toX = 2;
		var toY = 7;

		var consoleMoveInput = new ConsoleMoveInput(moveString, board);
        Assert.AreEqual(new Coordinate(fromX, fromY), consoleMoveInput.Move.From.Coordinate);
        Assert.AreEqual(new Coordinate(toX, toY), consoleMoveInput.Move.To.Coordinate);
    }

	private static BoardViewModel GetBoard()
	{
		return new BoardViewModel(BoardTestHelper.Create());
	}
}
