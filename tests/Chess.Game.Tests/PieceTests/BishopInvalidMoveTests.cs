using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BishopInvalidMoveTests
{
	[TestCaseSource(typeof(BishopInvalidMoveTestDataCollection), nameof(BishopInvalidMoveTestDataCollection.TestCases))]
	public void ShouldBeAbleToMoveIfEmpty(Func<Board, Move> getFromToWithBoard, Func<Board, Cell> getBlockingCell)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Bishop());
		var middleCellWithAnotherPiece = getBlockingCell(fromTo.Board);
		middleCellWithAnotherPiece.SetPiece(WhitePieceDecoratorTestHelper.Create(new Knight(), fromTo.Board));
		
		MoveTestHelper.AssertIsNotValidMove(fromTo.Move);
	}

	private class BishopInvalidMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveWithBlockingPieceInTheMiddleUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.a6), board => board.b5)
					.SetName("Move up left not allowed if blocked");
				yield return new MoveWithBlockingPieceInTheMiddleUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.f7), board => board.e6)
					.SetName("Move up right not allowed if blocked");
				yield return new MoveWithBlockingPieceInTheMiddleUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.a2), board => board.b3)
					.SetName("Move down left not allowed if blocked");
				yield return new MoveWithBlockingPieceInTheMiddleUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.f1), board => board.e2)
					.SetName("Move down right not allowed if blocked");
			}
		}
	}
}
