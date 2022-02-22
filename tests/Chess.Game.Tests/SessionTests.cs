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
	}

	[Test]
	public void ShouldStartWhitePlayerClockWhenGameStarts()
	{
		var whiteClock = new Clock(new TestDateTimeProvider());
		var blackClock = new Clock(new TestDateTimeProvider());
		var board = BoardTestHelper.Create();
		var moveHistory = MoveHistoryTestHelper.Create(board);
		var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
			SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(),
			board, moveHistory);
		session.Start();
		Assert.IsTrue(whiteClock.Ticking);
		Assert.IsFalse(blackClock.Ticking);
	}

	[Test]
	public void ShouldStartCorrectPlayerClockWhenItIsTheirTurn()
	{
		var whiteClock = new Clock(new TestDateTimeProvider());
		var blackClock = new Clock(new TestDateTimeProvider());
		var sessionPlayers = SessionPlayersTestHelper.Create(whiteClock, blackClock);

		var session = SessionTestHelper.GetStartedSession(sessionPlayers);

		Assert.IsTrue(whiteClock.Ticking);
		Assert.IsFalse(blackClock.Ticking);

		var move = session.Board.a2.GetMove(session.Board.a4);
		session.Move(move);

		Assert.IsFalse(whiteClock.Ticking);
		Assert.IsTrue(blackClock.Ticking);
	}

	[Test]
	public void ShouldStoreMovesWhenNextCalled()
	{
		var session = SessionTestHelper.GetStartedSession();
		
		var move = session.Board.a2.GetMove(session.Board.a4);
		session.Move(move);
		Assert.AreEqual(1, session.MoveHistory.Count());
		Assert.AreEqual(session.MoveHistory.First(), move);

		move = session.Board.b7.GetMove(session.Board.b5);
		session.Move(move);
		Assert.AreEqual(2, session.MoveHistory.Count());
		Assert.AreEqual(session.MoveHistory.First(), move);
	}

	[Test]
	public void ShouldRemoveMovesWhenBackCalled()
	{
		var session = SessionTestHelper.GetStartedSession();
		
		var move = session.Board.a2.GetMove(session.Board.a4);
		session.Move(move);

		move = session.Board.b7.GetMove(session.Board.b5);
		session.Move(move);

		var moveToTakeBackLater = session.Board.a4.GetMove(session.Board.b5);
		session.Move(moveToTakeBackLater);

		var lastMove = session.Back();
		Assert.AreEqual(2, session.MoveHistory.Count());
		Assert.AreEqual(session.MoveHistory.First(), move);
		Assert.AreEqual(moveToTakeBackLater, lastMove);
	}

	[Test]
	public void ShouldInvokeMoveEventWhenAValidMoveIsMade()
	{
		bool isEventCallbackInvoked = false;
		var session = SessionTestHelper.GetStartedSession();
		session.AddMoveEventCallback(move => isEventCallbackInvoked = true);
		
		var move = session.Board.a2.GetMove(session.Board.a4);
		session.Move(move);

		Assert.IsTrue(isEventCallbackInvoked);
	}

	[Test]
	public void ShouldCallRegister()
	{
		var sessionPlayerRegistrarSpy = new SessionPlayerRegistrarSpy();
		var board = BoardTestHelper.Create();
		var moveHistory = MoveHistoryTestHelper.Create(board);
		var session = new Session(SessionPlayersTestHelper.CreateWithoutRegister(), sessionPlayerRegistrarSpy, SessionStateMachineTestHelper.CreateDummy(),
			board, moveHistory);
		session.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer());
				session.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer());

		Assert.IsTrue(sessionPlayerRegistrarSpy.IsRegisterBlackCalled);
		Assert.IsTrue(sessionPlayerRegistrarSpy.IsRegisterWhiteCalled);
	}

	[Test]
	public void ShouldCallReady()
	{
		var sessionPlayersSpy = new SessionPlayersSpy();
		var board = BoardTestHelper.Create();
		var moveHistory = MoveHistoryTestHelper.Create(board);
		var session = new Session(sessionPlayersSpy, SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(),
			board, moveHistory);
		
		session.SetBlackPlayerReady();
		session.SetWhitePlayerReady();

		Assert.IsTrue(sessionPlayersSpy.IsBlackPlayerReadyCalled);
		Assert.IsTrue(sessionPlayersSpy.IsWhitePlayerReadyCalled);
	}

	[Test]
	public void ShouldTransitionToTheCorrectStatesWhenPlayersRegisterAndMove()
	{
		var board = BoardTestHelper.Create();
		var moveHistory = MoveHistoryTestHelper.Create(board);
		var session = new Session(SessionPlayersTestHelper.Create(),
			SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.Create(), board, moveHistory);

		board.SetOpeningPosition();

		session.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer());
		session.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer());
		session.SetBlackPlayerReady();
		session.SetWhitePlayerReady();
		session.Start();
		
		Assert.IsInstanceOf<SessionStateWhiteMove>(session.CurrentState);

		var move = board.a2.GetMove(board.a4);
		session.Move(move);
		Assert.IsInstanceOf<SessionStateBlackMove>(session.CurrentState);
		
		move = board.b7.GetMove(board.b5);
		session.Move(move);
		Assert.IsInstanceOf<SessionStateWhiteMove>(session.CurrentState);

		session.Back();
		Assert.IsInstanceOf<SessionStateBlackMove>(session.CurrentState);
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

	private class SessionPlayersSpy : SessionPlayers
	{
		public SessionPlayersSpy()
			: base(SessionPlayerRegistrarTestHelper.Create())
		{
		}

		public bool IsBlackPlayerReadyCalled { get; private set; }
		public bool IsWhitePlayerReadyCalled { get; private set; }

		public override void SetBlackPlayerReady()
		{
			this.IsBlackPlayerReadyCalled = true;
		}

		public override void SetWhitePlayerReady()
		{
			this.IsWhitePlayerReadyCalled = true;
		}
	}
}
