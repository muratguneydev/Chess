namespace Chess.Game
{
	[Serializable]
	public class InvalidSessionStateTransitionException : Exception
	{
		public InvalidSessionStateTransitionException(SessionState currentState, SessionStateTransitionCommand command)
			 : base($"Invalid session state transition from current state: '{currentState}' with command '{command}'.")
		{
			
		}
	}
}