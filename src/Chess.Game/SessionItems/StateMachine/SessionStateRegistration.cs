namespace Chess.Game;

public class SessionStateRegistration : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.RegisterBlack, new SessionStateBlackRegistered() },
			{ SessionStateTransitionCommand.RegisterWhite, new SessionStateWhiteRegistered() }
		};
}
