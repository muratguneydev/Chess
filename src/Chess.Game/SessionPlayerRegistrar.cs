namespace Chess.Game;

public class SessionPlayerRegistrar
{
	private readonly OnPlayersRegisteredEvent OnPlayersRegistered = new OnPlayersRegisteredEvent();
	public WhitePlayer WhitePlayer { get; private set; } = EmptyWhitePlayer.WhitePlayer;
	public BlackPlayer BlackPlayer { get; private set; } = EmptyBlackPlayer.BlackPlayer;

	public virtual void RegisterBlackPlayer(BlackPlayer player)
	{
		this.BlackPlayer = player;
		
		if (this.AllPlayersRegistered)
			this.OnPlayersRegistered.Invoke(this);
	}

	public virtual void RegisterWhitePlayer(WhitePlayer player)
	{
		this.WhitePlayer = player;

		if (this.AllPlayersRegistered)
			this.OnPlayersRegistered.Invoke(this);
	}

	public virtual void AddPlayersRegisteredEventCallback(Action<SessionPlayerRegistrar> callback)
	{
		this.OnPlayersRegistered.PlayersRegisteredEvent += callback;
	}

	public bool AllPlayersRegistered => !this.WhitePlayer.IsEmpty && !this.BlackPlayer.IsEmpty;
}