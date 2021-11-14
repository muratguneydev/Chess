using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BishopAttackTests
{
	[TestCaseSource(typeof(BishopAttackTestDataCollection), nameof(BishopAttackTestDataCollection.TestCases))]
	public void ShouldAttackCorrectly(Func<Board, Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Bishop());
		var destinationCellWithAnotherPiece = fromTo.Move.To;
		destinationCellWithAnotherPiece.Initialize(new BlackPieceDecorator(new Knight(), fromTo.Session, fromTo.Board, destinationCellWithAnotherPiece));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	private class BishopAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.a6))
					.SetName("Attack up left");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.f7))
					.SetName("Attack up right");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.a2))
					.SetName("Attack down left");
				yield return new FromToUsingBoardTestData(board => new Move(board.c4, board.f1))
					.SetName("Attack down right");
			}
		}
	}
}