using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class QueenMoveTests
{
	[TestCaseSource(typeof(QueenMoveTestDataCollection), nameof(QueenMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board,Move> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new Queen());

		MoveTestHelper.AssertIsValidMove(fromToForTest);
	}

	private class QueenMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a1, board.a5))
					.SetName("Move up if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a5, board.a1))
					.SetName("Move down if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a1, board.e1))
					.SetName("Move right if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.e1, board.a1))
					.SetName("Move left if not blocked");

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
