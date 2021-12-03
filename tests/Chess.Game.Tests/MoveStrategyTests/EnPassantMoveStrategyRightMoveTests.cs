using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class EnPassantMoveStrategyRightMoveTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveRightIfRightNeighbourPieceIsSameColor()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new WhitePawn(), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftCell = board.d5;
		var leftPiece = new TestPiece(new WhitePawn(), Color.White);
		leftCell.SetPiece(leftPiece);

		var toCell = board.d6;
		
		var move = new Move(fromCell, toCell);
		
		CellTestHelper.AssertIsNotValidMove(new EnPassantMoveStrategy(board).GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedToMoveRightIfRightNeighbourCellIsEmpty()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new WhitePawn(), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftEmptyCell = board.d5;
		
		var toCell = board.d6;
		
		var move = new Move(fromCell, toCell);
		
		CellTestHelper.AssertIsNotValidMove(new EnPassantMoveStrategy(board).GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedToMoveRightIfRightNeighbourPieceIsNotPawn()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new WhitePawn(), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftCell = board.d5;
		var leftPiece = new TestPiece(new Queen(), Color.White);
		leftCell.SetPiece(leftPiece);

		var toCell = board.d6;
		
		var move = new Move(fromCell, toCell);
		
		CellTestHelper.AssertIsNotValidMove(new EnPassantMoveStrategy(board).GetMovePath(move));
	}
}