namespace Chess.Game;

public abstract class SessionState
{
	protected abstract Dictionary<SessionStateTransitionCommand, SessionState> transitions { get; }

	public virtual SessionState MoveNext(SessionStateTransitionCommand command)
	{
		return this.GetNext(command);
	}

	private SessionState GetNext(SessionStateTransitionCommand command)
	{
		if (!this.transitions.TryGetValue(command, out var nextState))
			throw new InvalidSessionStateTransitionException(this, command);
		return nextState;
	}
}

