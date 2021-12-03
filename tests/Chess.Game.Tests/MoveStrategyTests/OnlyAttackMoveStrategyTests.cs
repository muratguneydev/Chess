using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class OnlyAttackMoveStrategyTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveToEmptyCell()
	{
		var fromCell = new Cell(new Coordinate(1,1));
		var piece = new TestPiece();
		fromCell.SetPiece(piece);
		
		var destinationCell = new Cell(new Coordinate(2,2));
		var move = new Move(fromCell, destinationCell);
		
		CellTestHelper.AssertIsNotValidMove(new OnlyAttackMoveStrategy(new TestMoveStrategy()).GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedIfDestinationIsOccupiedBySameColor()
	{
		var fromCell = new Cell(new Coordinate(1,1));
		var piece = new TestPiece();
		fromCell.SetPiece(piece);
		
		var destinationCell = new Cell(new Coordinate(2,2));
		var pieceToBeAttacked = new TestPiece();
		destinationCell.SetPiece(pieceToBeAttacked);

		var move = new Move(fromCell, destinationCell);
		
		CellTestHelper.AssertIsNotValidMove(new OnlyAttackMoveStrategy(new TestMoveStrategy()).GetMovePath(move));
	}

	[Test]
	public void ShouldBeAllowedToMoveForForAttack()
	{
		var fromCell = new Cell(new Coordinate(1,1));
		var whitePiece = new TestPiece(Color.White);
		fromCell.SetPiece(whitePiece);
		
		var destinationCell = new Cell(new Coordinate(2,2));
		var pieceToBeAttacked = new TestPiece(Color.Black);
		destinationCell.SetPiece(pieceToBeAttacked);

		var move = new Move(fromCell, destinationCell);
		
		CellTestHelper.AssertIsValidMove(new OnlyAttackMoveStrategy(new TestMoveStrategy()).GetMovePath(move));
	}
}
