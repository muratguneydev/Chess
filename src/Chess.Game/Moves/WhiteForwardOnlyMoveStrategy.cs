namespace Chess.Game;

public class WhiteForwardOnlyMoveStrategy : IMoveStrategy
{
	private readonly IMoveStrategy moveStrategy;

	public WhiteForwardOnlyMoveStrategy(IMoveStrategy moveStrategy)
	{
		this.moveStrategy = moveStrategy;
	}

	public MovePath GetMovePath(Move move)
	{
		if (move.From.Y >= move.To.Y)
			return new InvalidMovePath(move);

		return this.moveStrategy.GetMovePath(move);
	}
}
