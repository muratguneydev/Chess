namespace Chess.Game;

public class OnPlayersRegisteredEvent
{
	public event Action<SessionPlayerRegistrar>? PlayersRegisteredEvent;

    public void Invoke(SessionPlayerRegistrar sessionPlayerRegistrar)
    {
        if (this.PlayersRegisteredEvent == null)
			return;
        
		this.PlayersRegisteredEvent(sessionPlayerRegistrar);
	}
}
