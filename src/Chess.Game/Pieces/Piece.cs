namespace Chess.Game;

public abstract class Piece
{
	private readonly IMoveStrategy moveStrategy;

	public Piece(IMoveStrategy moveStrategy)
	{
		this.moveStrategy = moveStrategy;
	}

	public MovePath GetMovePath(Move fromTo)
	{
		return this.moveStrategy.GetMovePath(fromTo);
	}
}