namespace Chess.Game;

public class SessionStateBlackRegistered : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.RegisterWhite, new SessionStateGettingReady() }
		};
}
