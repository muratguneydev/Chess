using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class RookAttackTests
{
	[TestCaseSource(typeof(RookAttackTestDataCollection), nameof(RookAttackTestDataCollection.TestCases))]
	public void ShouldAttackCorrectly(Func<Board, FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Rook());
		var destinationCellWithAnotherPiece = fromTo.FromTo.To;
		destinationCellWithAnotherPiece.Initialize(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board, destinationCellWithAnotherPiece));
		
		CellTestHelper.AssertIsValidMove(fromTo.FromTo);
	}

	private class RookAttackTestDataCollection
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
			}
		}
	}
}
