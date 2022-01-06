using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KingMoveTests
{
	[TestCaseSource(typeof(KingMoveTestDataCollection), nameof(KingMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board, Move> getFromToWithBoard)
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
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.b5))
					.SetName("Move up left if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d5))
					.SetName("Move up right if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.b3))
					.SetName("Move down left if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d3))
					.SetName("Move down right if not blocked");
				
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a1, board.a2))
					.SetName("Move up if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a2, board.a1))
					.SetName("Move down if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a1, board.b1))
					.SetName("Move right if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.b1, board.a1))
					.SetName("Move left if not blocked");
			}
		}
	}
}
