using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class WhitePawnAttackTests
{
	[TestCaseSource(typeof(WhitePawnAttackTestDataCollection), nameof(WhitePawnAttackTestDataCollection.TestCases))]
	public void ShouldBeAbleToAttack(Func<Board,Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, board => new WhitePawn(board));
		var cellToBeAttacked = fromTo.Move.To;;
		cellToBeAttacked.SetPiece(BlackPieceDecoratorTestHelper.Create(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	[Test]
	public void ShouldBeAllowedToAttackEnPassant()
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
		CellTestHelper.AssertIsValidMove(testMove);
	}

	private class WhitePawnAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => new Move(board.a2, board.b3))
					.SetName("Attack on first move a2-b3");
				yield return new MoveUsingBoardTestData(board => new Move(board.c4, board.d5))
					.SetName("Attack on later moves c4-d5");
			}
		}
	}
}
