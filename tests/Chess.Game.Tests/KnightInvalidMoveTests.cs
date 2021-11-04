using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KnightInvalidMoveTests
{
	[TestCaseSource(typeof(KnightInvalidMoveTestDataCollection), nameof(KnightInvalidMoveTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveIfIfPathBlocked(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Knight());
		var blockingCellWithAnotherPiece = fromTo.FromTo.To;
		blockingCellWithAnotherPiece.Initialize(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board, blockingCellWithAnotherPiece));
		
		CellTestHelper.AssertIsNotValidMove(fromTo.FromTo);
	}

	private class KnightInvalidMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d6))
					.SetName("Move two up one right not allowed if blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b6))
					.SetName("Move two up one left not allowed if blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.e5))
					.SetName("Move one up two right not allowed if blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a5))
					.SetName("Move one up two left not allowed if blocked");

				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d2))
					.SetName("Move two down one right not allowed if blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b2))
					.SetName("Move two down one left not allowed if blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.e3))
					.SetName("Move one down two right not allowed if blocked");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a3))
					.SetName("Move one down two left not allowed if blocked");
			}
		}
	}
}
