using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BlackPawnInvalidMoveTests
{
	[TestCaseSource(typeof(BlackPawnInvalidMoveWhenBlockedTestDataCollection), nameof(BlackPawnInvalidMoveWhenBlockedTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveIfIfPathBlocked(Func<Board,FromTo> getFromToWithBoard, Func<Board, Cell> getMiddleCell)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellBlackPiece(getFromToWithBoard, new BlackPawn());
		var blockingCellWithAnotherPiece = getMiddleCell(fromTo.Board);
		blockingCellWithAnotherPiece.Initialize(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board, blockingCellWithAnotherPiece));
		
		CellTestHelper.AssertIsNotValidMove(fromTo.FromTo);
	}

	[TestCaseSource(typeof(BlackPawnInvalidMoveTestDataCollection), nameof(BlackPawnInvalidMoveTestDataCollection.TestCases))]
	public void ShouldDetectInvalidMoveWhenNotBlocked(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellBlackPiece(getFromToWithBoard, new BlackPawn());
		
		CellTestHelper.AssertIsNotValidMove(fromTo.FromTo);
	}

	[TestCaseSource(typeof(BlackPawnInvalidAttackTestDataCollection), nameof(BlackPawnInvalidAttackTestDataCollection.TestCases))]
	public void ShouldDetectInvalidAttack(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellBlackPiece(getFromToWithBoard, new BlackPawn());
		var cellToAttack = fromTo.FromTo.To;
		cellToAttack.Initialize(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board, cellToAttack));
		
		CellTestHelper.AssertIsNotValidMove(fromTo.FromTo);
	}

	private class BlackPawnInvalidMoveWhenBlockedTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.a7, board.a5), board => board.a6)
					.SetName("Move 2 squares as first move not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.a7, board.a6), board => board.a6)
					.SetName("Move 1 square as first move not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new FromTo(board.b6, board.c5), board => board.c5)
					.SetName("Move diagonal 1 square not allowed when not attacking ie same color in destination");
			}
		}
	}

	private class BlackPawnInvalidMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a6, board.a4))
					.SetName("Move 2 squares after first move a6-a4 not allowed");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.b6, board.c5))
					.SetName("Move diagonal 1 square not allowed when not attacking ie destination empty");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.b4, board.b5))
					.SetName("Move backwards 1 square not allowed");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.b4, board.b6))
					.SetName("Move backwards 2 squares not allowed");
			}
		}
	}

	private class BlackPawnInvalidAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c5, board.b6))
					.SetName("Attack backwards left not allowed");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c5, board.d6))
					.SetName("Attack backwards right not allowed");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c3, board.c4))
					.SetName("Attack backwards vertical not allowed");
			}
		}
	}
}
