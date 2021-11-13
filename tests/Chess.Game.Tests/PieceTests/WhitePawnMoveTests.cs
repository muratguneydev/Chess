using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class WhitePawnMoveTests
{
	[TestCaseSource(typeof(WhitePawnMoveTestDataCollection), nameof(WhitePawnMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new WhitePawn());

		CellTestHelper.AssertIsValidMove(fromToForTest);
	}

	private class WhitePawnMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a2, board.a4))
					.SetName("Move 2 squares as first move if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a2, board.a3))
					.SetName("Move 1 square as first move if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a3, board.a4))
					.SetName("Move 1 square after the first move a3-a4 if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a4, board.a5))
					.SetName("Move 1 square after the first move a4-a5 if not blocked");
			}
		}
	}
}
