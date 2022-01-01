namespace Chess.Game;

public class OnPlayersReadyEvent
{
	public event Action<SessionPlayers>? PlayersReadyEvent;

    public void Invoke(SessionPlayers sessionPlayers)
    {
        if (this.PlayersReadyEvent == null)
			return;
        
		this.PlayersReadyEvent(sessionPlayers);
	}
}