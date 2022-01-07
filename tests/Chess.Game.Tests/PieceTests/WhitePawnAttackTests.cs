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
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getMoveWithBoard, board => new WhitePawn(board));
		var cellToBeAttacked = fromTo.Move.To;
		cellToBeAttacked.SetPiece(BlackPieceDecoratorTestHelper.Create(new Knight(), fromTo.Board));
		
		MoveTestHelper.AssertIsValidMove(fromTo.Move);
	}

	[Test]
	public void ShouldBeAllowedToAttackEnPassant()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create();
		
		var attackingPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn(board), board);
		var attackedPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn(board), board);
		var otherPiece = WhitePieceDecoratorTestHelper.Create(new Queen(), board);
		
		board.b4.SetPiece(attackingPawn);
		board.c7.SetPiece(attackedPawn);
		board.a1.SetPiece(otherPiece);
		session.Start();

		var move = board.b4.GetMove(board.b5);
		session.Move(move);

		move = board.c7.GetMove(board.c5);
		session.Move(move);
		
		var testMove = board.b5.GetMove(board.c6);
		MoveTestHelper.AssertIsValidMove(testMove);

		session.Move(testMove);
		Assert.IsFalse(board.c5.IsOccupied);
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
