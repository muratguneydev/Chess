using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class GameTests
{
    [Test]
    public void WhenBeginningOfTheGameThereAreNoWinners()
    {
		var session = SessionTestHelper.Create();
		Assert.AreEqual(EmptyWinner.Winner, session.Winner);
    }

	[Test]
    public void WhenBeginningOfTheGameItsNotOver()
    {
		var session = SessionTestHelper.Create();
        Assert.IsFalse(session.IsComplete);
    }

	[Test]
    public void ShouldNotLetTheBlackStartFirst()
    {
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		board.SetOpeningPosition();
		session.Start();

		CellTestHelper.AssertIsNotValidMove(new Move(board.e7, board.e5));
    }
}

public class MoveTests
{
    [Test]
    public void ShouldTakeBack()
    {
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		board.SetOpeningPosition();
		session.Start();

		var move = board.a2.Move(board.a4);
		Assert.AreEqual(typeof(WhitePawn), board.a4.Piece.PieceType);
		Assert.IsFalse(board.a2.IsOccupied);
		session.Next(move);

		move = board.b7.Move(board.b5);
		Assert.AreEqual(typeof(BlackPawn), board.b5.Piece.PieceType);
		Assert.IsFalse(board.b7.IsOccupied);
		session.Next(move);

		var lastMove = session.Back();
		Assert.AreEqual(typeof(BlackPawn), board.b7.Piece.PieceType);
		Assert.IsFalse(board.b5.IsOccupied);
		
    }
}
