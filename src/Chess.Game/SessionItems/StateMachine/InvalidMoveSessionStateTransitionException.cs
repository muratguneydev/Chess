namespace Chess.Game
{
	[Serializable]
	public class InvalidMoveSessionStateTransitionException : Exception
	{
		public InvalidMoveSessionStateTransitionException(SessionState currentState)
			 : base($"Invalid session state transition from current state: '{currentState}' with a move command.")
		{
			
		}
	}
}