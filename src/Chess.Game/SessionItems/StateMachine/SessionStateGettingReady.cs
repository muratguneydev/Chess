namespace Chess.Game;

public class SessionStateGettingReady : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.ReadyBlack, new SessionStateBlackReady() },
			{ SessionStateTransitionCommand.ReadyWhite, new SessionStateWhiteReady() }
		};
}
