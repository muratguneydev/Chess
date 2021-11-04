using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class RookMoveTests
{
	[TestCaseSource(typeof(RookMoveTestDataCollection), nameof(RookMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new Rook());

		CellTestHelper.AssertIsValidMove(fromToForTest);
	}

	private class RookMoveTestDataCollection
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
			}
		}
	}
}
