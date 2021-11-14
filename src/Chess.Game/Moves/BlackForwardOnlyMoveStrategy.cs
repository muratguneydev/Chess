namespace Chess.Game;

public class BlackForwardOnlyMoveStrategy : IMoveStrategy
{
	private readonly IMoveStrategy moveStrategy;

	public BlackForwardOnlyMoveStrategy(IMoveStrategy moveStrategy)
	{
		this.moveStrategy = moveStrategy;
	}

	public MovePath GetMovePath(Move fromTo)
	{
		if (fromTo.From.Y <= fromTo.To.Y)
			return new InvalidMovePath(fromTo);

		return this.moveStrategy.GetMovePath(fromTo);
	}
}