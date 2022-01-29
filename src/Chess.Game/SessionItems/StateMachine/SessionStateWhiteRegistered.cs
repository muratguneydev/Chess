namespace Chess.Game;

public class SessionStateWhiteRegistered : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.RegisterBlack, new SessionStateGettingReady() }
		};
}
