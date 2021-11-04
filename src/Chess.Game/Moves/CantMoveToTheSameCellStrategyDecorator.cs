namespace Chess.Game;

public class CantMoveToTheCurrentCellStrategyDecorator : IMoveStrategy
{
	private readonly IMoveStrategy moveStrategy;

	public CantMoveToTheCurrentCellStrategyDecorator(IMoveStrategy moveStrategy)
	{
		this.moveStrategy = moveStrategy;
	}

	public MovePath GetMovePath(FromTo fromTo)
	{
		if (fromTo.From.X == fromTo.To.X && fromTo.From.Y == fromTo.To.Y)
			return new InvalidMovePath(fromTo);
		
		return this.moveStrategy.GetMovePath(fromTo);
	}
}