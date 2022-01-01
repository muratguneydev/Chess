namespace Chess.Game;

public class SessionPlayers
{
	private readonly OnPlayersReadyEvent OnPlayersReady = new OnPlayersReadyEvent();
	private readonly SessionPlayerRegistrar sessionPlayerRegistrar;

	public SessionPlayers(SessionPlayerRegistrar sessionPlayerRegistrar)
	{
		this.sessionPlayerRegistrar = sessionPlayerRegistrar;
	}

	public WhitePlayer WhitePlayer => this.sessionPlayerRegistrar.WhitePlayer;
	public BlackPlayer BlackPlayer => this.sessionPlayerRegistrar.BlackPlayer;

	public void SetWhitePlayerReady()
	{
		this.WhitePlayer.SetReady();

		if (this.AllPlayersReady)
			this.OnPlayersReady.Invoke(this);
	}

	public void SetBlackPlayerReady()
	{
		this.BlackPlayer.SetReady();

		if (this.AllPlayersReady)
			this.OnPlayersReady.Invoke(this);
	}

	public void AddPlayersReadyEventCallback(Action<SessionPlayers> callback)
	{
		this.OnPlayersReady.PlayersReadyEvent += callback;
	}

	public virtual bool IsReady => this.AllPlayersReady;
	
	private bool AllPlayersReady => this.WhitePlayer.IsReady && this.BlackPlayer.IsReady;
}
