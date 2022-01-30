namespace Chess.Game;

public class OnMoveEvent
{
	public event Action<Move>? MoveEvent;

    public void Invoke(Move move)
    {
        if (this.MoveEvent == null)
			return;
        
		this.MoveEvent(move);
	}
}
