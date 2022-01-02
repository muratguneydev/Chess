namespace Chess.Game;

public class SessionStateGettingReady : SessionState
{
	private bool isBlackReady;
	private bool isWhiteReady;
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.ReadyBlack, this },
			{ SessionStateTransitionCommand.ReadyWhite, this }
		};

	public override SessionState MoveNext(SessionStateTransitionCommand command)
	{
		if (command == SessionStateTransitionCommand.ReadyBlack)
			this.isBlackReady = true;
		if (command == SessionStateTransitionCommand.ReadyWhite)
			this.isWhiteReady = true;

		if (this.isBlackReady && this.isWhiteReady)
			return new SessionStateWhiteMove();
		
		return base.MoveNext(command);
	}
}
