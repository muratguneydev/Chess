using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BishopMoveTests
{
	[TestCaseSource(typeof(BishopMoveTestDataCollection), nameof(BishopMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board, Move> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new Bishop());

		CellTestHelper.AssertIsValidMove(fromToForTest);
	}

	private class BishopMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.b5))
					.SetName("Move up left if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.a6))
					.SetName("Move up left to the edge if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d5))
					.SetName("Move up right if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.f7))
					.SetName("Move up right to the edge if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.b3))
					.SetName("Move down left if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.a2))
					.SetName("Move down left to the edge if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d3))
					.SetName("Move down right if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.f1))
					.SetName("Move down right to the edge if not blocked");
			}
		}
	}
}
