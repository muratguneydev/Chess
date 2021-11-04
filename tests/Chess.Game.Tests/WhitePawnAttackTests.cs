using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class WhitePawnAttackTests
{
	[TestCaseSource(typeof(WhitePawnAttackTestDataCollection), nameof(WhitePawnAttackTestDataCollection.TestCases))]
	public void ShouldBeAbleToAttack(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new WhitePawn());
		var cellToBeAttacked = fromTo.FromTo.To;;
		cellToBeAttacked.Initialize(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board, cellToBeAttacked));
		
		CellTestHelper.AssertIsValidMove(fromTo.FromTo);
	}

	private class WhitePawnAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a2, board.b3))
					.SetName("Attack on first move a2-b3");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d5))
					.SetName("Attack on later moves c4-d5");
			}
		}
	}
}
