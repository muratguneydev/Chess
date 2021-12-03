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
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new WhitePawn());
		var cellToBeAttacked = fromTo.Move.To;;
		cellToBeAttacked.SetPiece(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	private class WhitePawnAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new Move(board.a2, board.b3))
					.SetName("Attack on first move a2-b3");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.d5))
					.SetName("Attack on later moves c4-d5");
			}
		}
	}
}
