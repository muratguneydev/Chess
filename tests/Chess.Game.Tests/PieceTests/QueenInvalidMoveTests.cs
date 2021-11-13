using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class QueenInvalidMoveTests
{
	[TestCaseSource(typeof(QueenInvalidMoveTestDataCollection), nameof(QueenInvalidMoveTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveIfIfPathBlocked(Func<Board,FromTo> getFromToWithBoard, Func<Board, Cell> getMiddleCell)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Rook());
		var middleCellWithAnotherPiece = getMiddleCell(fromTo.Board);
		middleCellWithAnotherPiece.Initialize(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board, middleCellWithAnotherPiece));
		
		CellTestHelper.AssertIsNotValidMove(fromTo.FromTo);
	}

	private class QueenInvalidMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.a1, board.e1), board => board.b1)
					.SetName("Move right not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.c1, board.a1), board => board.b1)
					.SetName("Move left not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.a1, board.a5), board => board.a3)
					.SetName("Move up not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.a5, board.a1), board => board.a3)
					.SetName("Move down not allowed if blocked");

				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.c4, board.a6), board => board.b5)
					.SetName("Move up left not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.c4, board.f7), board => board.e6)
					.SetName("Move up right not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.c4, board.a2), board => board.b3)
					.SetName("Move down left not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.c4, board.f1), board => board.e2)
					.SetName("Move down right not allowed if blocked");
			}
		}
	}
}
