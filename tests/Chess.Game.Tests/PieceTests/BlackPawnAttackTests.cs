using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

//Note: En-passant tests are covered in the EnPassantMoveStrategyTests.cs.
public class BlackPawnAttackTests
{
	[TestCaseSource(typeof(BlackPawnAttackTestDataCollection), nameof(BlackPawnAttackTestDataCollection.TestCases))]
	public void ShouldBeAbleToAttack(Func<Board,Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellBlackPiece(getFromToWithBoard, board => new BlackPawn());
		var cellToBeAttacked = fromTo.Move.To;
		cellToBeAttacked.SetPiece(WhitePieceDecoratorTestHelper.Create(new Knight()));
		
		MoveTestHelper.AssertIsValidMove(fromTo.Move);
	}

	[Test]
	public void ShouldBeAllowedToAttackEnPassant()
	{
		var session = SessionTestHelper.GetStartedSessionWithEmptyBoard();
		
		var attackingPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn());
		var attackedPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn());
		
		session.Board.b4.SetPiece(attackingPawn);
		session.Board.c2.SetPiece(attackedPawn);
		session.Start();

		var move = session.Board.c2.GetMove(session.Board.c4);
		session.Move(move);
		
		var testMove = session.Board.b4.GetMove(session.Board.c3);
		MoveTestHelper.AssertIsValidMove(testMove);

		session.Move(testMove);
		Assert.IsFalse(session.Board.c4.IsOccupied);
	}

	[Test]
	public void ShouldNotBeAllowedToAttackEnPassantIfOpponentDidntMove2Forward()
	{
		var session = SessionTestHelper.GetStartedSessionWithEmptyBoard();
		
		var attackingPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn());
		var attackedPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn());
		
		session.Board.b3.SetPiece(attackingPawn);
		session.Board.c2.SetPiece(attackedPawn);
		session.Start();

		var move = session.Board.c2.GetMove(session.Board.c3);
		session.Move(move);
		
		var testMove = MoveTestHelper.Create(session.Board.b3, session.Board.c2);
		MoveTestHelper.AssertIsNotValidMove(testMove);
	}

	private class BlackPawnAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.b7, board.a6))
					.SetName("Attack on first move b7-a6");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.d5, board.c4))
					.SetName("Attack on later moves d5-c4");
			}
		}
	}
}
