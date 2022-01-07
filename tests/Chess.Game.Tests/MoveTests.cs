using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class MoveTests
{
    [Test]
    public void ShouldTakeBack()
    {
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create();
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
}
