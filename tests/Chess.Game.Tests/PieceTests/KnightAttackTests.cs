using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KnightAttackTests
{
	[TestCaseSource(typeof(KnightAttackTestDataCollection), nameof(KnightAttackTestDataCollection.TestCases))]
	public void ShouldNotBeAbleToMoveIfIfPathBlocked(Func<Board,Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Knight());
		var blockingCellWithAnotherPiece = fromTo.Move.To;
		blockingCellWithAnotherPiece.SetPiece(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	private class KnightAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.d6))
					.SetName("Attack two up one right");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.b6))
					.SetName("Attack two up one left");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.e5))
					.SetName("Attack one up two right");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.a5))
					.SetName("Attack one up two left");

				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.d2))
					.SetName("Attack two down one right");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.b2))
					.SetName("Attack two down one left");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.e3))
					.SetName("Attack one down two right");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.a3))
					.SetName("Attack one down two left");
			}
		}
	}
}
