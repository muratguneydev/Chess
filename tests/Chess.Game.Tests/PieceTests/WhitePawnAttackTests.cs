using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class WhitePawnAttackTests
{
	[TestCaseSource(typeof(WhitePawnAttackTestDataCollection), nameof(WhitePawnAttackTestDataCollection.TestCases))]
	public void ShouldBeAbleToAttack(Func<Board,Move> getMoveWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getMoveWithBoard, board => new WhitePawn());
		var cellToBeAttacked = fromTo.Move.To;
		cellToBeAttacked.SetPiece(BlackPieceDecoratorTestHelper.Create(new Knight()));
		
		MoveTestHelper.AssertIsValidMove(fromTo.Move);
	}

	[Test]
	public void ShouldBeAllowedToAttackEnPassant()
	{
		var session = SessionTestHelper.GetStartedSessionWithEmptyBoard();
		
		var attackingPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn());
		var attackedPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn());
		var otherPiece = WhitePieceDecoratorTestHelper.Create(new Queen());
		
		session.Board.b4.SetPiece(attackingPawn);
		session.Board.c7.SetPiece(attackedPawn);
		session.Board.a1.SetPiece(otherPiece);
		session.Start();

		var move = session.Board.b4.GetMove(session.Board.b5);
		session.Move(move);

		move = session.Board.c7.GetMove(session.Board.c5);
		session.Move(move);
		
		var testMove = session.Board.b5.GetMove(session.Board.c6);
		MoveTestHelper.AssertIsValidMove(testMove);

		session.Move(testMove);
		Assert.IsFalse(session.Board.c5.IsOccupied);
	}

	private class WhitePawnAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a2, board.b3))
					.SetName("Attack on first move a2-b3");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d5))
					.SetName("Attack on later moves c4-d5");
			}
		}
	}
}
