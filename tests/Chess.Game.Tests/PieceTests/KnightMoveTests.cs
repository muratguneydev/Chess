using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KnightMoveTests
{
	[TestCaseSource(typeof(KnightMoveTestDataCollection), nameof(KnightMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfNotBlocked(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Knight());
		
		CellTestHelper.AssertIsValidMove(fromTo.FromTo);
	}

	private class KnightMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d6))
					.SetName("Move two up one right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b6))
					.SetName("Move two up one left");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.e5))
					.SetName("Move one up two right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a5))
					.SetName("Move one up two left");

				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d2))
					.SetName("Move two down one right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b2))
					.SetName("Move two down one left");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.e3))
					.SetName("Move one down two right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a3))
					.SetName("Move one down two left");
			}
		}
	}
}