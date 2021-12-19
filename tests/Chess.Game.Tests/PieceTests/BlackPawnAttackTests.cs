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
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellBlackPiece(getFromToWithBoard, board => new BlackPawn(board));
		var cellToBeAttacked = fromTo.Move.To;
		cellToBeAttacked.SetPiece(WhitePieceDecoratorTestHelper.Create(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	[Test]
	public void ShouldBeAllowedToAttackEnPassant()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		
		var attackingPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn(board), session, board);
		var attackedPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn(board), session, board);
		
		board.b4.SetPiece(attackingPawn);
		board.c2.SetPiece(attackedPawn);
		session.Start();

		session.Next(board.c2.Move(board.c4));
		
		var testMove = new Move(board.b4, board.c3);
		CellTestHelper.AssertIsValidMove(testMove);
	}

	[Test]
	public void ShouldNotBeAllowedToAttackEnPassantIfOpponentDidntMove2Forward()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		
		var attackingPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn(board), session, board);
		var attackedPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn(board), session, board);
		
		board.b3.SetPiece(attackingPawn);
		board.c2.SetPiece(attackedPawn);
		session.Start();

		session.Next(board.c2.Move(board.c3));
		
		var testMove = new Move(board.b3, board.c2);
		CellTestHelper.AssertIsNotValidMove(testMove);
	}

	private class BlackPawnAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => new Move(board.b7, board.a6))
					.SetName("Attack on first move b7-a6");
				yield return new MoveUsingBoardTestData(board => new Move(board.d5, board.c4))
					.SetName("Attack on later moves d5-c4");
			}
		}
	}
}
