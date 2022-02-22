using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class EnPassantMoveStrategyTests
{
	[Test]
	public void ShouldNotBeAllowedToMoveIfOpponentPieceIsNotPawn()
	{
		var board = BoardTestHelper.Create();

		var fromCell = board.c5;
		var whitePiece = new TestPiece(new Queen(), Color.White);
		fromCell.SetPiece(whitePiece);
		
		var leftCell = board.b5;
		var leftPiece = new TestPiece(new BlackPawn(), Color.Black);
		leftCell.SetPiece(leftPiece);

		var toCell = board.b6;
		
		var move = MoveTestHelper.Create(fromCell, toCell);
		
		MoveTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy().GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedToMoveIfNotOpponentPieceFirstMove()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create();
		
		var attackingPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn());
		var attackedPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn());
		var otherPiece = WhitePieceDecoratorTestHelper.Create(new Queen());
		
		board.b4.SetPiece(attackingPawn);
		board.c7.SetPiece(attackedPawn);
		board.a1.SetPiece(otherPiece);
		session.Start();

		session.Move(board.b4.GetMove(board.b5));
		session.Move(board.c7.GetMove(board.c6));
		session.Move(board.a1.GetMove(board.a2));
		session.Move(board.c6.GetMove(board.c5));
		
		var testMove = MoveTestHelper.Create(board.b5, board.c6);
		
		MoveTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy().GetMovePath(testMove));
	}

	[Test]
	public void ShouldBeAllowedToMoveIfOpponentPieceFirstMove()
	{
		var session = SessionTestHelper.GetStartedSessionWithEmptyBoard();
		
		var attackingPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn());
		var attackedPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn());
		var otherPiece = WhitePieceDecoratorTestHelper.Create(new Queen());
		
		session.Board.b4.SetPiece(attackingPawn);
		session.Board.c7.SetPiece(attackedPawn);
		session.Board.a1.SetPiece(otherPiece);
		session.Start();

		session.Move(session.Board.b4.GetMove(session.Board.b5));
		session.Move(session.Board.c7.GetMove(session.Board.c5));
		
		var testMove = MoveTestHelper.Create(session.Board.b5, session.Board.c6);
		
		MoveTestHelper.AssertIsValidMove(new WhiteEnPassantMoveStrategy().GetMovePath(testMove));
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
		
		var move = MoveTestHelper.Create(fromCell, toCell);
		
		MoveTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy().GetMovePath(move));
	}
}
