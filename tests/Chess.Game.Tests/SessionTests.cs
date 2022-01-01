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
				var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
					SessionPlayerRegistrarTestHelper.Create());
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
				var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
					SessionPlayerRegistrarTestHelper.Create());
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
				var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
					SessionPlayerRegistrarTestHelper.Create());
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
				var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
					SessionPlayerRegistrarTestHelper.Create());
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

	[Test]
	public void ShouldInvokeMoveEventWhenAValidMoveIsMade()
	{
		bool isEventCallbackInvoked = false;
		var session = SessionTestHelper.Create();
		session.AddMoveEventCallback(move => isEventCallbackInvoked = true);

		var board = BoardTestHelper.Create(session);
		board.SetOpeningPosition();

		session.Start();
		
		var move = board.a2.Move(board.a4);
		session.Next(move);

		Assert.IsTrue(isEventCallbackInvoked);
	}

	[Test]
	public void ShouldCallRegister()
	{
		var sessionPlayerRegistrarSpy = new SessionPlayerRegistrarSpy();
		var session = new Session(SessionPlayersTestHelper.CreateWithoutRegister(), sessionPlayerRegistrarSpy);
		
		using (var whiteClock = new Clock(new TimerWrapper()))
		{
			using (var blackClock = new Clock(new TimerWrapper()))
			{
				session.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer(blackClock));
				session.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer(whiteClock));
			}
		}
	}

	private class SessionPlayerRegistrarSpy : SessionPlayerRegistrar
	{
		public bool IsRegisterBlackCalled { get; private set; }
		public bool IsRegisterWhiteCalled { get; private set; }

		public override void RegisterBlackPlayer(BlackPlayer player)
		{
			this.IsRegisterBlackCalled = true;
		}

		public override void RegisterWhitePlayer(WhitePlayer player)
		{
			this.IsRegisterWhiteCalled = true;
		}
	}
}
