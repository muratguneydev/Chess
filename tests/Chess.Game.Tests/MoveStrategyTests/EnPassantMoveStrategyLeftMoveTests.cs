using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class EnPassantMoveStrategyLeftMoveTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveLeftIfLeftNeighbourPieceIsSameColor()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new WhitePawn(board), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftCell = board.b5;
		var leftPiece = new TestPiece(new WhitePawn(board), Color.White);
		leftCell.SetPiece(leftPiece);

		var toCell = board.b6;
		
		var move = MoveTestHelper.Create(fromCell, toCell);
		
		MoveTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy(board).GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedToMoveLeftIfLeftNeighbourCellIsEmpty()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new WhitePawn(board), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftEmptyCell = board.b5;
		
		var toCell = board.b6;
		
		var move = MoveTestHelper.Create(fromCell, toCell);
		
		MoveTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy(board).GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedToMoveLeftIfLeftNeighbourPieceIsNotPawn()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new WhitePawn(board), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftCell = board.b5;
		var leftPiece = new TestPiece(new Queen(), Color.White);
		leftCell.SetPiece(leftPiece);

		var toCell = board.b6;
		
		var move = MoveTestHelper.Create(fromCell, toCell);
		
		MoveTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy(board).GetMovePath(move));
	}
}
