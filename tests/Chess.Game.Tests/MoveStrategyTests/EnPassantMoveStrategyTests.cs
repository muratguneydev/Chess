using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class EnPassantMoveStrategyTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveIfPieceIsNotPawn()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new Queen(), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftCell = board.b5;
		var leftPiece = new TestPiece(new BlackPawn(), Color.Black);
		leftCell.SetPiece(leftPiece);

		var toCell = board.b6;
		
		var move = new Move(fromCell, toCell);
		
		CellTestHelper.AssertIsNotValidMove(new EnPassantMoveStrategy(board).GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedToMoveToOccupiedCell()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.b2;
		var whitePiece = new TestPiece(Color.White);
		fromCell.SetPiece(whitePiece);
		
		var toCell = board.c3;
		var blackPiece = new TestPiece(Color.Black);
		toCell.SetPiece(blackPiece);
		
		var move = new Move(fromCell, toCell);
		
		CellTestHelper.AssertIsNotValidMove(new EnPassantMoveStrategy(board).GetMovePath(move));
	}
}
