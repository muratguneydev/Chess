using System.Linq;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class SessionTests
{
	[Test]
	public void ShouldStartWithWhitePlayer()
	{
		var session = SessionTestHelper.Create();
		session.Start();
		Assert.AreEqual(Color.White, session.CurrentPlayer.Color);
		//TODO: Should we dispose the players->timers?
	}

	[Test]
	public void ShouldStartWhitePlayerClockWhenGameStarts()
	{
		using (var whiteClock = new Clock(new TimerWrapper()))
		{
			using (var blackClock = new Clock(new TimerWrapper()))
			{
				var whitePlayer = PlayerTestHelper.CreateWhitePlayer(whiteClock);
				var blackPlayer = PlayerTestHelper.CreateBlackPlayer(blackClock);
				var session = new Session(whitePlayer, blackPlayer);
				session.Start();
				Assert.IsTrue(whiteClock.Ticking);
				Assert.IsFalse(blackClock.Ticking);
			}
		}
	}

	[Test]
	public void ShouldStartCorrectPlayerClockWhenItIsTheirTurn()
	{
		using (var whiteClock = new Clock(new TimerWrapper()))
		{
			using (var blackClock = new Clock(new TimerWrapper()))
			{
				var whitePlayer = PlayerTestHelper.CreateWhitePlayer(whiteClock);
				var blackPlayer = PlayerTestHelper.CreateBlackPlayer(blackClock);
				var session = new Session(whitePlayer, blackPlayer);

				var board = BoardTestHelper.Create(session);
				board.SetOpeningPosition();

				session.Start();
				
				Assert.IsTrue(whiteClock.Ticking);
				Assert.IsFalse(blackClock.Ticking);

				var move = board.a2.Move(board.a4);
				session.Next(move);
				
				Assert.IsFalse(whiteClock.Ticking);
				Assert.IsTrue(blackClock.Ticking);
			}
		}
	}

	[Test]
	public void ShouldStoreMovesWhenNextCalled()
	{
		using (var whiteClock = new Clock(new TimerWrapper()))
		{
			using (var blackClock = new Clock(new TimerWrapper()))
			{
				var whitePlayer = PlayerTestHelper.CreateWhitePlayer(whiteClock);
				var blackPlayer = PlayerTestHelper.CreateBlackPlayer(blackClock);
				var session = new Session(whitePlayer, blackPlayer);

				var board = BoardTestHelper.Create(session);
				board.SetOpeningPosition();

				session.Start();
				
				var move = board.a2.Move(board.a4);
				session.Next(move);
				Assert.AreEqual(1, session.MoveHistory.Count());
				Assert.AreEqual(session.MoveHistory.First(), move);

				move = board.b7.Move(board.b5);
				session.Next(move);
				Assert.AreEqual(2, session.MoveHistory.Count());
				Assert.AreEqual(session.MoveHistory.First(), move);
			}
		}
	}

	[Test]
	public void ShouldRemoveMovesWhenBackCalled()
	{
		using (var whiteClock = new Clock(new TimerWrapper()))
		{
			using (var blackClock = new Clock(new TimerWrapper()))
			{
				var whitePlayer = PlayerTestHelper.CreateWhitePlayer(whiteClock);
				var blackPlayer = PlayerTestHelper.CreateBlackPlayer(blackClock);
				var session = new Session(whitePlayer, blackPlayer);

				var board = BoardTestHelper.Create(session);
				board.SetOpeningPosition();

				session.Start();
				
				var move = board.a2.Move(board.a4);
				session.Next(move);

				move = board.b7.Move(board.b5);
				session.Next(move);

				var moveToTakeBackLater = board.a4.Move(board.b5);
				session.Next(moveToTakeBackLater);

				var lastMove = session.Back();
				Assert.AreEqual(2, session.MoveHistory.Count());
				Assert.AreEqual(session.MoveHistory.First(), move);
				Assert.AreEqual(moveToTakeBackLater, lastMove);
			}
		}
	}
}