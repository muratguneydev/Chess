using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class WhitePawnInvalidMoveTests
{
	[TestCaseSource(typeof(WhitePawnInvalidMoveWhenBlockedTestDataCollection), nameof(WhitePawnInvalidMoveWhenBlockedTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveIfIfPathBlocked(Func<Board,Move> getFromToWithBoard, Func<Board, Cell> getMiddleCell)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new WhitePawn());
		var middleCellWithAnotherPiece = getMiddleCell(fromTo.Board);
		middleCellWithAnotherPiece.Initialize(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board, middleCellWithAnotherPiece));
		
		CellTestHelper.AssertIsNotValidMove(fromTo.Move);
	}

	[TestCaseSource(typeof(WhitePawnInvalidMoveTestDataCollection), nameof(WhitePawnInvalidMoveTestDataCollection.TestCases))]
	public void ShouldDetectInvalidMoveWhenNotBlocked(Func<Board,Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new WhitePawn());
		
		CellTestHelper.AssertIsNotValidMove(fromTo.Move);
	}

	[TestCaseSource(typeof(WhitePawnInvalidAttackTestDataCollection), nameof(WhitePawnInvalidAttackTestDataCollection.TestCases))]
	public void ShouldDetectInvalidAttack(Func<Board,Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new WhitePawn());
		var cellToAttack = fromTo.Move.To;
		cellToAttack.Initialize(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board, cellToAttack));
		
		CellTestHelper.AssertIsNotValidMove(fromTo.Move);
	}

	private class WhitePawnInvalidMoveWhenBlockedTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.a2, board.a4), board => board.a3)
					.SetName("Move 2 squares as first move not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.a2, board.a3), board => board.a3)
					.SetName("Move 1 square as first move not allowed if blocked");
				yield return new FromToWithBlockingPieceInTheMiddleUsingBoardTestData(board => new Move(board.b3, board.c4), board => board.c4)
					.SetName("Move diagonal 1 square not allowed when not attacking ie same color in destination");
			}
		}
	}

	private class WhitePawnInvalidMoveTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new Move(board.a3, board.a5))
					.SetName("Move 2 squares after first move a3-a5 not allowed when not blocked");
				yield return new FromToUsingBoardTestData(board => new Move(board.b3, board.c4))
					.SetName("Move diagonal 1 square not allowed when not attacking ie destination empty");
				yield return new FromToUsingBoardTestData(board => new Move(board.b4, board.b3))
					.SetName("Move backwards 1 square not allowed");
				yield return new FromToUsingBoardTestData(board => new Move(board.b4, board.b2))
					.SetName("Move backwards 2 squares not allowed");
			}
		}
	}

	private class WhitePawnInvalidAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new Move(board.c3, board.b2))
					.SetName("Attack backwards left not allowed");
				yield return new FromToUsingBoardTestData(board => new Move(board.c3, board.d2))
					.SetName("Attack backwards right not allowed");
				yield return new FromToUsingBoardTestData(board => new Move(board.c3, board.c2))
					.SetName("Attack backwards vertical not allowed");
			}
		}
	}
}
