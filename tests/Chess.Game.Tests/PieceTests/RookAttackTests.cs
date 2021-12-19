using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class RookAttackTests
{
	[TestCaseSource(typeof(RookAttackTestDataCollection), nameof(RookAttackTestDataCollection.TestCases))]
	public void ShouldAttackCorrectly(Func<Board, Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Rook());
		var destinationCellWithAnotherPiece = fromTo.Move.To;
		destinationCellWithAnotherPiece.SetPiece(BlackPieceDecoratorTestHelper.Create(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	private class RookAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => new Move(board.a1, board.a5))
					.SetName("Attack up");
				yield return new MoveUsingBoardTestData(board => new Move(board.a5, board.a1))
					.SetName("Attack down");
				yield return new MoveUsingBoardTestData(board => new Move(board.a1, board.e1))
					.SetName("Attack right");
				yield return new MoveUsingBoardTestData(board => new Move(board.e1, board.a1))
					.SetName("Attack left");
			}
		}
	}
}
