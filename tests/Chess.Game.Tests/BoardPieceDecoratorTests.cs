using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BoardPieceDecoratorTests
{
	[Test]
	public void ShouldNotBeAbleToMoveToTheSameCell()
	{
		var cell = new Cell(new Coordinate(0, 0));
		var piece = new TestPiece(cell);
		cell.Initialize(piece);

		CellTestHelper.AssertIsNotValidMove(new Move(cell, cell));
		//Assert.IsFalse(piece.Move(cell).IsValid);
	}

	[Test]
	public void ShouldValidMoveClearCurrentCell()
	{
		var fromCell = new Cell(new Coordinate(0, 0));
		var piece = new TestPiece(fromCell);
		fromCell.Initialize(piece);

		var toCell = new Cell(new Coordinate(0, 7));

		fromCell.Move(toCell);
		Assert.AreEqual(EmptyBoardPiece.Piece, fromCell.Piece);
	}

	[Test]
	public void ShouldValidMovePopulateDestinationCell()
	{
		var fromCell = new Cell(new Coordinate(0, 0));
		var piece = new TestPiece(fromCell);
		fromCell.Initialize(piece);

		var toCell = new Cell(new Coordinate(0, 7));

		fromCell.Move(toCell);
		Assert.AreEqual(piece, toCell.Piece);
	}
}
