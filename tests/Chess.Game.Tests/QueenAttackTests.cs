using System;
using System.Collections;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class QueenAttackTests
{
	[TestCaseSource(typeof(QueenAttackTestDataCollection), nameof(QueenAttackTestDataCollection.TestCases))]
	public void ShouldAttackCorrectly(Func<Board, FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Queen());
		var destinationCellWithAnotherPiece = fromTo.FromTo.To;
		destinationCellWithAnotherPiece.Initialize(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board, destinationCellWithAnotherPiece));
		
		CellTestHelper.AssertIsValidMove(fromTo.FromTo);
	}

	private class QueenAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a1, board.a5))
					.SetName("Attack up");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a5, board.a1))
					.SetName("Attack down");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.a1, board.e1))
					.SetName("Attack right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.e1, board.a1))
					.SetName("Attack left");

				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a6))
					.SetName("Attack up left");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.f7))
					.SetName("Attack up right");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.a2))
					.SetName("Attack down left");
				yield return new FromToUsingBoardTestData(board => new FromTo(board.c4, board.f1))
					.SetName("Attack down right");
			}
		}
	}
}