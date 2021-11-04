using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KnightAttackTests
{
	[TestCaseSource(typeof(KnightAttackTestDataCollection), nameof(KnightAttackTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveIfIfPathBlocked(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Knight());
		var blockingCellWithAnotherPiece = fromTo.FromTo.To;
		blockingCellWithAnotherPiece.Initialize(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board, blockingCellWithAnotherPiece));
		
		CellTestHelper.AssertIsValidMove(fromTo.FromTo);
	}

	private class KnightAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d6))
					.SetName("Attack two up one right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b6))
					.SetName("Attack two up one left");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.e5))
					.SetName("Attack one up two right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a5))
					.SetName("Attack one up two left");

				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.d2))
					.SetName("Attack two down one right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.b2))
					.SetName("Attack two down one left");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.e3))
					.SetName("Attack one down two right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a3))
					.SetName("Attack one down two left");
			}
		}
	}
}
