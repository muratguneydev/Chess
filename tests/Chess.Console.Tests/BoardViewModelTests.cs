using Chess.Game;
using NUnit.Framework;

namespace Chess.Console.Tests;

public class BoardViewModelTests
{
	[TestCase("z2", TestName="Invalid x in cell name")]
    [TestCase("a9", TestName="Invalid y in cell name")]
    public void ShouldThrowArgumentExceptionForInvalidCellName(string cellString)
	{
		var boardViewModel = GetBoard();

		Assert.Throws<InvalidCellNameException>(() => boardViewModel.GetCell(cellString));
	}

	[TestCase("c8", 2, 7, TestName="Parse cell c8 correctly from cell name")]
    public void ShouldParseCellsCorrectlyFromCellString(string cellString, int expectedX, int expectedY)
    {
		var boardViewModel = GetBoard();

		var cell = boardViewModel.GetCell(cellString);
        Assert.AreEqual(new Coordinate(expectedX, expectedY), cell.Coordinate);
    }

	[TestCase(2, 7, "c8", TestName="Should produce cell name c8 correctly from cell")]
	[TestCase(0, 0, "a1", TestName="Should produce cell name a1 correctly from cell")]
	[TestCase(7, 7, "h8", TestName="Should produce cell name h8 correctly from cell")]
    public void ShouldGetCellNameCorrectly(int x, int y, string cellString)
    {
		var boardViewModel = GetBoard();

		Assert.AreEqual(cellString, boardViewModel.GetCellName(new Cell(new Coordinate(x, y))));
    }

	private static BoardViewModel GetBoard()
	{
		var whitePlayer = new WhitePlayer();
		var blackPlayer = new BlackPlayer();
		var session = new Session(whitePlayer, blackPlayer);
		var board = new Board(session);
		board.SetOpeningPosition();
		return new BoardViewModel(board);;
	}
}