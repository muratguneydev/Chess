namespace Chess.Game.Tests.Helpers;

public static class SessionStateMachineTestHelper
{
	public static SessionStateMachine Create()
	{
		return new SessionStateMachine();
	}

	public static SessionStateMachine CreateDummy()
	{
		return new SessionStateMachineDummy();
	}
}

public class SessionStateMachineDummy : SessionStateMachine
{
	private SessionState defaultState = new SessionStateRegistration();

	public override SessionState SetWhiteReady()
	{
		return defaultState;
	}

	public override SessionState SetBlackReady()
	{
		return defaultState;
	}

	public override SessionState RegisterBlack()
	{
		return defaultState;
	}

	public override SessionState RegisterWhite()
	{
		return defaultState;
	}

	public override SessionState Move()
	{
		return defaultState;
	}

	public override SessionState Back()
	{
		return defaultState;
	}

	public override SessionState Exit()
	{
		return defaultState;
	}
}
