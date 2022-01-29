namespace Chess.Game;

public class SessionStateWhiteReady : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.ReadyBlack, new SessionStateWhiteMove() }
		};
}
