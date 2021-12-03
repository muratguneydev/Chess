using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KingInvalidMoveTests
{
	[TestCaseSource(typeof(KingInvalidMoveWhenBlockedTestDataCollection), nameof(KingInvalidMoveWhenBlockedTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveIfBlocked(Func<Board, Move> getFromToWithBoard, Func<Board, Cell> getBlockingCell)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new King());
		var middleCellWithAnotherPiece = getBlockingCell(fromTo.Board);
		middleCellWithAnotherPiece.SetPiece(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsNotValidMove(fromTo.Move);
	}

	[TestCaseSource(typeof(KingInvalidMoveMoreThanOneSquarTestDataCollection), nameof(KingInvalidMoveMoreThanOneSquarTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveMoreThanOneSquare(Func<Board, Move> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new King());
		
		CellTestHelper.AssertIsNotValidMove(fromToForTest);
	}

	private class KingInvalidMoveWhenBlockedTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.b5), board => board.b5)
					.SetName("Move up left not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.d5), board => board.d5)
					.SetName("Move up right not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.b3), board => board.b3)
					.SetName("Move down left not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.d3), board => board.d3)
					.SetName("Move down right not allowed if blocked");

				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.c5), board => board.c5)
					.SetName("Move up not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.c3), board => board.c3)
					.SetName("Move down not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.d4), board => board.d4)
					.SetName("Move right not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.c4, board.b4), board => board.b4)
					.SetName("Move left not allowed if blocked");
			}
		}
	}

	private class KingInvalidMoveMoreThanOneSquarTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.a6))
					.SetName("Move up left to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.f7))
					.SetName("Move up right to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.a2))
					.SetName("Move down left to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.f1))
					.SetName("Move down right to the edge if not blocked");

				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.c8))
					.SetName("Move up to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.c1))
					.SetName("Move down to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.a4))
					.SetName("Move left to the edge if not blocked");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.h4))
					.SetName("Move  right to the edge if not blocked");
			}
		}
	}
}