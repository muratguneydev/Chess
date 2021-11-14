namespace Chess.Game;

public class OnlyAttackMoveStrategy : IMoveStrategy
{
	private readonly IMoveStrategy moveStrategy;

	public OnlyAttackMoveStrategy(IMoveStrategy moveStrategy)
	{
		this.moveStrategy = moveStrategy;
	}

	public MovePath GetMovePath(Move fromTo)
	{
		if ((!fromTo.To.IsOccupied) || fromTo.HasSameColor)
			return new InvalidMovePath(fromTo);

		return this.moveStrategy.GetMovePath(fromTo);
	}
}