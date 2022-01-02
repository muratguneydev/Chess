namespace Chess.Game;

public class SessionStateRegistration : SessionState
{
	private bool isBlackRegistered;
	private bool isWhiteRegistered;
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.RegisterBlack, this },
			{ SessionStateTransitionCommand.RegisterWhite, this }
		};

	public override SessionState MoveNext(SessionStateTransitionCommand command)
	{
		if (command == SessionStateTransitionCommand.RegisterBlack)
			this.isBlackRegistered = true;
		if (command == SessionStateTransitionCommand.RegisterWhite)
			this.isWhiteRegistered = true;

		if (this.isBlackRegistered && this.isWhiteRegistered)
			return new SessionStateGettingReady();
		
		return base.MoveNext(command);
	}
}
