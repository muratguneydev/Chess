using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class MoveTests
{
    [Test]
    public void ShouldTakeBack()
    {
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		board.SetOpeningPosition();
		session.Start();

		var move = board.a2.GetMove(board.a4);
		session.Move(move);
		Assert.AreEqual(typeof(WhitePawn), board.a4.Piece.PieceType);
		Assert.IsFalse(board.a2.IsOccupied);

		move = board.b7.GetMove(board.b5);
		session.Move(move);
		Assert.AreEqual(typeof(BlackPawn), board.b5.Piece.PieceType);
		Assert.IsFalse(board.b7.IsOccupied);

		var lastMove = session.Back();
		Assert.AreEqual(typeof(BlackPawn), board.b7.Piece.PieceType);
		Assert.IsFalse(board.b5.IsOccupied);
		
    }

	// [Test]
	// public void ShouldBeAllowedToAttackEnPassant()
	// {
	// 	var session = SessionTestHelper.Create();
	// 	var board = BoardTestHelper.Create(session);
		
	// 	var attackingPawn = BlackPieceDecoratorTestHelper.Create(new BlackPawn(board), session, board);
	// 	var attackedPawn = WhitePieceDecoratorTestHelper.Create(new WhitePawn(board), session, board);
		
	// 	board.b4.SetPiece(attackingPawn);
	// 	board.c2.SetPiece(attackedPawn);
	// 	session.Start();

	// 	var move = board.c2.GetMove(board.c4);
	// 	session.Move(move);
		
	// 	var testMove = board.b4.GetMove(board.c3);
	// 	//CellTestHelper.AssertIsValidMove(testMove);

	// 	session.Move(testMove);
	// 	Assert.IsFalse(board.c4.IsOccupied);
	// }
}
