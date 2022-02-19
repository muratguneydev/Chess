using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class SessionStateMachineTests
{
	[Test]
	public void ShouldThrowExceptionWhenWhitePlayerMadeReadyWhileInAWrongState_SessionIntegration()
	{
		var sessionPlayers = SessionPlayersTestHelper.CreateWithoutRegister();
		var sessionPlayerRegistrar = SessionPlayerRegistrarTestHelper.Create();
		var board = BoardTestHelper.Create();
		var moveHistory = MoveHistoryTestHelper.Create(board);
		var session = new Session(sessionPlayers, sessionPlayerRegistrar, SessionStateMachineTestHelper.Create(), board, moveHistory);

		Assert.Throws<InvalidSessionStateTransitionException>(() => session.SetWhitePlayerReady());
	}

	[Test]
	public void ShouldThrowExceptionWhenWhitePlayerMadeReadyWhileInAWrongState()
	{
		var sessionStateMachine = new SessionStateMachine();
		Assert.IsInstanceOf<SessionStateRegistration>(sessionStateMachine.CurrentState);
		Assert.Throws<InvalidSessionStateTransitionException>(() => sessionStateMachine.SetWhiteReady());
	}

	[Test]
	public void ShouldApplyCorrectTransition()
	{
		var sessionStateMachine = new SessionStateMachine();
		Assert.IsInstanceOf<SessionStateRegistration>(sessionStateMachine.CurrentState);
		sessionStateMachine.RegisterBlack();
		Assert.IsInstanceOf<SessionStateBlackRegistered>(sessionStateMachine.CurrentState);
		sessionStateMachine.RegisterWhite();
		Assert.IsInstanceOf<SessionStateGettingReady>(sessionStateMachine.CurrentState);
		sessionStateMachine.SetBlackReady();
		Assert.IsInstanceOf<SessionStateBlackReady>(sessionStateMachine.CurrentState);
		sessionStateMachine.SetWhiteReady();
		Assert.IsInstanceOf<SessionStateWhiteMove>(sessionStateMachine.CurrentState);
		sessionStateMachine.Move();
		Assert.IsInstanceOf<SessionStateBlackMove>(sessionStateMachine.CurrentState);
		sessionStateMachine.Move();
		Assert.IsInstanceOf<SessionStateWhiteMove>(sessionStateMachine.CurrentState);
	}
}
