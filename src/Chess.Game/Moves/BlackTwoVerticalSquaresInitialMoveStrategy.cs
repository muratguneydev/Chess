namespace Chess.Game;

public class BlackTwoVerticalSquaresInitialMoveStrategy : IMoveStrategy
{
	private readonly VerticalMoveStrategy verticalMoveStrategy;

	public BlackTwoVerticalSquaresInitialMoveStrategy(VerticalMoveStrategy verticalMoveStrategy)
	{
		this.verticalMoveStrategy = verticalMoveStrategy;
	}

	public MovePath GetMovePath(FromTo fromTo)
	{
		if (fromTo.From.Y != 6 || fromTo.To.Y != 4)
			return new InvalidMovePath(fromTo);

		return this.verticalMoveStrategy.GetMovePath(fromTo);
	}
}