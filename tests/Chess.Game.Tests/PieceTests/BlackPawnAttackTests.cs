using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BlackPawnAttackTests
{
	[TestCaseSource(typeof(BlackPawnAttackTestDataCollection), nameof(BlackPawnAttackTestDataCollection.TestCases))]
	public void ShouldBeAbleToAttack(Func<Board,Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellBlackPiece(getFromToWithBoard, new BlackPawn());
		var cellToBeAttacked = fromTo.Move.To;;
		cellToBeAttacked.SetPiece(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	private class BlackPawnAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new Move(board.b7, board.a6))
					.SetName("Attack on first move b7-a6");
				yield return new FromToUsingBoardTestData(board => new Move(board.d5, board.c4))
					.SetName("Attack on later moves d5-c4");
			}
		}
	}
}
