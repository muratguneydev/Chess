namespace Chess.Game;

public class SessionStateMachine
{
	public SessionState CurrentState { get; private set; } = new SessionStateRegistration();

	public virtual SessionState SetWhiteReady()
	{
		this.CurrentState = this.CurrentState.MoveNext(SessionStateTransitionCommand.ReadyWhite);
		return this.CurrentState;
	}

	public virtual SessionState SetBlackReady()
	{
		this.CurrentState = CurrentState.MoveNext(SessionStateTransitionCommand.ReadyBlack);
		return this.CurrentState;
	}

	public virtual SessionState RegisterBlack()
	{
		this.CurrentState = CurrentState.MoveNext(SessionStateTransitionCommand.RegisterBlack);
		return this.CurrentState;
	}

	public virtual SessionState RegisterWhite()
	{
		this.CurrentState = CurrentState.MoveNext(SessionStateTransitionCommand.RegisterWhite);
		return this.CurrentState;
	}

	public virtual SessionState Move()
	{
		if (!(this.CurrentState is SessionStateBlackMove || this.CurrentState is SessionStateWhiteMove))
			throw new InvalidMoveSessionStateTransitionException(this.CurrentState);

		return this.CurrentState is SessionStateBlackMove
			? this.MoveBlack()
			: this.MoveWhite();
	}

	public virtual SessionState Back()
	{
		return this.Move();
	}

	public virtual SessionState Exit()
	{
		this.CurrentState = CurrentState.MoveNext(SessionStateTransitionCommand.Exit);
		return this.CurrentState;
	}

	private SessionState MoveBlack()
	{
		this.CurrentState = CurrentState.MoveNext(SessionStateTransitionCommand.MoveBlack);
		return this.CurrentState;
	}

	private SessionState MoveWhite()
	{
		this.CurrentState = CurrentState.MoveNext(SessionStateTransitionCommand.MoveWhite);
		return this.CurrentState;
	}
}