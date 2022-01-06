using System;
using System.Collections;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class KingAttackTests
{
	[TestCaseSource(typeof(KingAttackTestDataCollection), nameof(KingAttackTestDataCollection.TestCases))]
	public void ShouldAttackCorrectly(Func<Board, Move> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellWhitePiece(getFromToWithBoard, new King());
		var destinationCellWithAnotherPiece = fromTo.Move.To;
		destinationCellWithAnotherPiece.SetPiece(BlackPieceDecoratorTestHelper.Create(new Knight(), fromTo.Session, fromTo.Board));
		
		CellTestHelper.AssertIsValidMove(fromTo.Move);
	}

	private class KingAttackTestDataCollection
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.b5))
					.SetName("Attack up left");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d5))
					.SetName("Attack up right");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.b3))
					.SetName("Attack down left");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d3))
					.SetName("Attack down right");

				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.c5))
					.SetName("Attack up");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.c3))
					.SetName("Attack down");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.d4))
					.SetName("Attack right");
				yield return new MoveUsingBoardTestData(board => MoveTestHelper.Create(board.c4, board.b4))
					.SetName("Attack left");
			}
		}
	}
}
