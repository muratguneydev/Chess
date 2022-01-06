using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class CellTests
{
	[Test]
	public void ShouldNotBeAbleToMoveToTheSameCell()
	{
		var cell = CellTestHelper.Create(new Coordinate(0, 0));
		var piece = new TestPiece();
		cell.SetPiece(piece);

		CellTestHelper.AssertIsNotValidMove(MoveTestHelper.Create(cell, cell));
	}

	[Test]
	public void ShouldValidMoveClearCurrentCell()
	{
		var fromCell = CellTestHelper.Create(new Coordinate(0, 0));
		var piece = new TestPiece();
		fromCell.SetPiece(piece);

		var toCell = CellTestHelper.Create(new Coordinate(0, 7));

		var move = fromCell.GetMove(toCell);
		move.Go();
		Assert.AreEqual(EmptyBoardPiece.Piece, fromCell.Piece);
	}

	[Test]
	public void ShouldValidMovePopulateDestinationCell()
	{
		var fromCell = CellTestHelper.Create(new Coordinate(0, 0));
		var piece = new TestPiece();
		fromCell.SetPiece(piece);

		var toCell = CellTestHelper.Create(new Coordinate(0, 7));

		var move = fromCell.GetMove(toCell);
		move.Go();
		Assert.AreEqual(piece, toCell.Piece);
	}
}
