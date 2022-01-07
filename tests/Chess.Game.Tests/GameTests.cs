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
		var board = BoardTestHelper.Create();
		board.SetOpeningPosition();
		session.Start();

		SessionTestHelper.AssertIsNotValidMove(session.Move(MoveTestHelper.Create(board.e7, board.e5)));
    }

	[Test]
    public void ShouldLetTheWhiteStartFirst()
    {
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create();
		board.SetOpeningPosition();
		session.Start();

		SessionTestHelper.AssertIsValidMove(session.Move(MoveTestHelper.Create(board.e2, board.e4)));
    }
}
