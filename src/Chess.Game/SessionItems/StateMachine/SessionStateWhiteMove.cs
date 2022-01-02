namespace Chess.Game;

public class SessionStateWhiteMove : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.MoveWhite, new SessionStateBlackMove() },
		};
}
