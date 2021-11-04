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

		CellTestHelper.AssertIsNotValidMove(new FromTo(board.e7, board.e5));
    }
}
