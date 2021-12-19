using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class QueenAttackTests
{
	[TestCaseSource(typeof(QueenAttackTestDataCollection), nameof(QueenAttackTestDataCollection.TestCases))]
	public void ShouldAttackCorrectly(Func<Board, Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new Queen());
		var destinationCellWithAnotherPiece = fromTo.Move.To;
		destinationCellWithAnotherPiece.SetPiece(BlackPieceDecoratorTestHelper.Create(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	private class QueenAttackTestDataCollection
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

				yield return new MoveUsingBoardTestData(board => new Move(board.c4, board.a6))
					.SetName("Attack up left");
				yield return new MoveUsingBoardTestData(board => new Move(board.c4, board.f7))
					.SetName("Attack up right");
				yield return new MoveUsingBoardTestData(board => new Move(board.c4, board.a2))
					.SetName("Attack down left");
				yield return new MoveUsingBoardTestData(board => new Move(board.c4, board.f1))
					.SetName("Attack down right");
			}
		}
	}
}