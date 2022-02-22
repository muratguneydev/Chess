using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class MoveTests
{
    [Test]
    public void ShouldTakeBack()
    {
		var session = SessionTestHelper.GetStartedSession();

		var a2OriginalPiece = session.Board.a2.Piece;
		var move = session.Board.a2.GetMove(session.Board.a4);
		session.Move(move);
		Assert.IsTrue(BoardPieceDecoratorTestHelper.Equals(a2OriginalPiece, session.Board.a4.Piece));
		Assert.IsFalse(session.Board.a2.IsOccupied);

		var b7OriginalPiece = session.Board.b7.Piece;
		move = session.Board.b7.GetMove(session.Board.b5);
		session.Move(move);
		Assert.IsTrue(BoardPieceDecoratorTestHelper.Equals(b7OriginalPiece, session.Board.b5.Piece));
		Assert.IsFalse(session.Board.b7.IsOccupied);

		var lastMove = session.Back();
		Assert.IsTrue(BoardPieceDecoratorTestHelper.Equals(b7OriginalPiece, session.Board.b7.Piece));
		Assert.IsFalse(session.Board.b5.IsOccupied);
    }
}
