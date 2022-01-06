namespace Chess.Game;

public class CompositeMoveStrategy : IMoveStrategy
{
	private readonly IEnumerable<IMoveStrategy> strategies;

	public CompositeMoveStrategy(IEnumerable<IMoveStrategy> strategies)
	{
		this.strategies = strategies;
	}
	public MovePath GetMovePath(Move move)
	{
		return this.strategies
			.Select(moveStrategy => moveStrategy.GetMovePath(move))
			.Where(movePath => movePath.IsValid)
			.DefaultIfEmpty(new InvalidMovePath(move))
			.Single();//Note: Only one strategy can return a valid move path.
	}
}
