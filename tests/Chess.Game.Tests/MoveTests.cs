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

		var a2OriginalPiece = board.a2.Piece;
		var move = board.a2.GetMove(board.a4);
		session.Move(move);
		Assert.IsTrue(BoardPieceDecoratorTestHelper.Equals(a2OriginalPiece, board.a4.Piece));
		Assert.IsFalse(board.a2.IsOccupied);

		var b7OriginalPiece = board.b7.Piece;
		move = board.b7.GetMove(board.b5);
		session.Move(move);
		Assert.IsTrue(BoardPieceDecoratorTestHelper.Equals(b7OriginalPiece, board.b5.Piece));
		Assert.IsFalse(board.b7.IsOccupied);

		var lastMove = session.Back();
		Assert.IsTrue(BoardPieceDecoratorTestHelper.Equals(b7OriginalPiece, board.b7.Piece));
		Assert.IsFalse(board.b5.IsOccupied);
    }
}
