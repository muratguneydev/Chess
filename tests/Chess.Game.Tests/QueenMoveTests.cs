using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class QueenMoveTests
{
	[TestCaseSource(typeof(QueenMoveTestDataCollection), nameof(QueenMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new Queen());

		CellTestHelper.AssertIsValidMove(fromToForTest);
	}

	private class QueenMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a1, board.a5))
					.SetName("Move up if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a5, board.a1))
					.SetName("Move down if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a1, board.e1))
					.SetName("Move right if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.e1, board.a1))
					.SetName("Move left if not blocked");

				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b5))
					.SetName("Move up left if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a6))
					.SetName("Move up left to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d5))
					.SetName("Move up right if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.f7))
					.SetName("Move up right to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b3))
					.SetName("Move down left if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a2))
					.SetName("Move down left to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d3))
					.SetName("Move down right if not blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.f1))
					.SetName("Move down right to the edge if not blocked");
			}
		}
	}
}
