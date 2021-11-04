namespace Chess.Game;

public class CompositeMoveStrategy : IMoveStrategy
{
	private readonly IEnumerable<IMoveStrategy> strategies;

	public CompositeMoveStrategy(IEnumerable<IMoveStrategy> strategies)
	{
		this.strategies = strategies;
	}
	public MovePath GetMovePath(FromTo fromTo)
	{
		if (NoneOfThePathsIsValid(fromTo))
			return new InvalidMovePath(fromTo);

		return new MovePath(fromTo,
			this.strategies.SelectMany(strategy => strategy.GetMovePath(fromTo).CoordinatesInPath));
	}

	private bool NoneOfThePathsIsValid(FromTo fromTo)
	{
		return this.strategies
					.Select(moveStrategy => moveStrategy.GetMovePath(fromTo))
					.All(movePath => !movePath.IsValid);
	}
}
