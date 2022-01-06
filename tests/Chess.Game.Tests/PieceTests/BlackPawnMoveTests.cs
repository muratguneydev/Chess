using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BlackPawnMoveTests
{
	[TestCaseSource(typeof(BlackPawnMoveTestDataCollection), nameof(BlackPawnMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board,Move> getMoveWithBoard)
	{
		var moveForTest = BoardTestHelper.InitializeBoardWithFromCell(getMoveWithBoard, board => new BlackPawn(board));

		CellTestHelper.AssertIsValidMove(moveForTest);
	}

	private class BlackPawnMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a7, board.a5))
					.SetName("Move 2 squares as first move if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a7, board.a6))
					.SetName("Move 1 square as first move if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a4, board.a3))
					.SetName("Move 1 square in later move a4-a3 if not blocked");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.a5, board.a4))
					.SetName("Move 1 square in later move a5-a4 if not blocked");
			}
		}
	}
}