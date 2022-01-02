namespace Chess.Game;

public class SessionStateBlackMove : SessionState
{
	protected override Dictionary<SessionStateTransitionCommand, SessionState> transitions => new Dictionary<SessionStateTransitionCommand, SessionState>
		{
			{ SessionStateTransitionCommand.Exit, new SessionStateQuitted() },
			{ SessionStateTransitionCommand.MoveBlack, new SessionStateWhiteMove() },
		};
}
