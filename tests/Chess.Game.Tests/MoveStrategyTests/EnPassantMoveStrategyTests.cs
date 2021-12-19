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
		var leftPiece = new TestPiece(new BlackPawn(board), Color.Black);
		leftCell.SetPiece(leftPiece);

		var toCell = board.b6;
		
		var move = new Move(fromCell, toCell);
		
		CellTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy(board).GetMovePath(move));
	}

	[Test]
	public void ShouldNotBeAllowedToMoveIfNotOpponentPieceFirstMove()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		
		var attackingPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn(board), session, board);
		var attackedPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn(board), session, board);
		var otherPiece = WhitePieceDecoratorTestHelper.Create(new Queen(), session, board);
		
		board.b4.SetPiece(attackingPawn);
		board.c7.SetPiece(attackedPawn);
		board.a1.SetPiece(otherPiece);
		session.Start();

		session.Next(board.b4.Move(board.b5));
		session.Next(board.c7.Move(board.c6));
		session.Next(board.a1.Move(board.a2));
		session.Next(board.c6.Move(board.c5));
		
		var testMove = new Move(board.b5, board.c6);
		
		CellTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy(board).GetMovePath(testMove));
	}

	[Test]
	public void ShouldBeAllowedToMoveIfOpponentPieceFirstMove()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		
		var attackingPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn(board), session, board);
		var attackedPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn(board), session, board);
		var otherPiece = WhitePieceDecoratorTestHelper.Create(new Queen(), session, board);
		
		board.b4.SetPiece(attackingPawn);
		board.c7.SetPiece(attackedPawn);
		board.a1.SetPiece(otherPiece);
		session.Start();

		session.Next(board.b4.Move(board.b5));
		session.Next(board.c7.Move(board.c5));
		
		var testMove = new Move(board.b5, board.c6);
		
		CellTestHelper.AssertIsValidMove(new WhiteEnPassantMoveStrategy(board).GetMovePath(testMove));
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
		
		CellTestHelper.AssertIsNotValidMove(new WhiteEnPassantMoveStrategy(board).GetMovePath(move));
	}
}
