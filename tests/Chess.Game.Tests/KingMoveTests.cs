using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KingMoveTests
{
	[TestCaseSource(typeof(KingMoveTestDataCollection), nameof(KingMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board, FromTo> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new King());

		CellTestHelper.AssertIsValidMove(fromToForTest);
	}

	private class KingMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b5))
					.SetName("Move up left if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d5))
					.SetName("Move up right if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b3))
					.SetName("Move down left if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d3))
					.SetName("Move down right if not blocked");
				
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a1, board.a2))
					.SetName("Move up if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a2, board.a1))
					.SetName("Move down if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a1, board.b1))
					.SetName("Move right if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.b1, board.a1))
					.SetName("Move left if not blocked");
			}
		}
	}
}
