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
		var whiteClock = new Clock();
		var blackClock = new Clock();
		var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
			SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(),
			BoardTestHelper.Create());
		session.Start();
		Assert.IsTrue(whiteClock.Ticking);
		Assert.IsFalse(blackClock.Ticking);
	}

	[Test]
	public void ShouldStartCorrectPlayerClockWhenItIsTheirTurn()
	{
		var whiteClock = new Clock();
		var blackClock = new Clock();
		var board = BoardTestHelper.Create();
		var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
			SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(), board);
		board.SetOpeningPosition();

		session.Start();
		
		Assert.IsTrue(whiteClock.Ticking);
		Assert.IsFalse(blackClock.Ticking);

		var move = board.a2.GetMove(board.a4);
		session.Move(move);
		
		Assert.IsFalse(whiteClock.Ticking);
		Assert.IsTrue(blackClock.Ticking);
	}

	[Test]
	public void ShouldStoreMovesWhenNextCalled()
	{
		var board = BoardTestHelper.Create();
		var session = new Session(SessionPlayersTestHelper.Create(),
			SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(), board);
		board.SetOpeningPosition();

		session.Start();
		
		var move = board.a2.GetMove(board.a4);
		session.Move(move);
		Assert.AreEqual(1, session.MoveHistory.Count());
		Assert.AreEqual(session.MoveHistory.First(), move);

		move = board.b7.GetMove(board.b5);
		session.Move(move);
		Assert.AreEqual(2, session.MoveHistory.Count());
		Assert.AreEqual(session.MoveHistory.First(), move);
	}

	[Test]
	public void ShouldRemoveMovesWhenBackCalled()
	{
		var board = BoardTestHelper.Create();
		var session = new Session(SessionPlayersTestHelper.Create(),
			SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(), board);
		board.SetOpeningPosition();

		session.Start();
		
		var move = board.a2.GetMove(board.a4);
		session.Move(move);

		move = board.b7.GetMove(board.b5);
		session.Move(move);

		var moveToTakeBackLater = board.a4.GetMove(board.b5);
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
		var board = BoardTestHelper.Create();
		var session = SessionTestHelper.Create(board: board);
		session.AddMoveEventCallback(move => isEventCallbackInvoked = true);

		board.SetOpeningPosition();

		session.Start();
		
		var move = board.a2.GetMove(board.a4);
		session.Move(move);

		Assert.IsTrue(isEventCallbackInvoked);
	}

	[Test]
	public void ShouldCallRegister()
	{
		var sessionPlayerRegistrarSpy = new SessionPlayerRegistrarSpy();
		var session = new Session(SessionPlayersTestHelper.CreateWithoutRegister(), sessionPlayerRegistrarSpy, SessionStateMachineTestHelper.CreateDummy(),
			BoardTestHelper.Create());
		session.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer());
				session.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer());

		Assert.IsTrue(sessionPlayerRegistrarSpy.IsRegisterBlackCalled);
		Assert.IsTrue(sessionPlayerRegistrarSpy.IsRegisterWhiteCalled);
	}

	[Test]
	public void ShouldCallReady()
	{
		var sessionPlayersSpy = new SessionPlayersSpy();
		var session = new Session(sessionPlayersSpy, SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(),
			BoardTestHelper.Create());
		
		session.SetBlackPlayerReady();
		session.SetWhitePlayerReady();

		Assert.IsTrue(sessionPlayersSpy.IsBlackPlayerReadyCalled);
		Assert.IsTrue(sessionPlayersSpy.IsWhitePlayerReadyCalled);
	}

	[Test]
	public void ShouldTransitionToTheCorrectStatesWhenPlayersRegisterAndMove()
	{
		var whiteClock = new Clock();
		var blackClock = new Clock();
		var board = BoardTestHelper.Create();
		var session = new Session(SessionPlayersTestHelper.Create(whiteClock, blackClock),
			SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.Create(), board);
		board.SetOpeningPosition();

		session.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer(clock: blackClock));
		session.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer(clock: whiteClock));
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
