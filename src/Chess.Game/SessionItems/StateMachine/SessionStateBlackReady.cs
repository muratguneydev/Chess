namespace Chess.Game;

public class SessionStateBlackReady : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.ReadyWhite, new SessionStateWhiteMove() }
		};
}