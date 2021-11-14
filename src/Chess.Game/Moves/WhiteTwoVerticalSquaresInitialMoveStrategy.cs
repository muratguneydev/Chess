namespace Chess.Game;

public class WhiteTwoVerticalSquaresInitialMoveStrategy : IMoveStrategy
{
	private readonly VerticalMoveStrategy verticalMoveStrategy;

	public WhiteTwoVerticalSquaresInitialMoveStrategy(VerticalMoveStrategy verticalMoveStrategy)
	{
		this.verticalMoveStrategy = verticalMoveStrategy;
	}

	public MovePath GetMovePath(Move fromTo)
	{
		if (fromTo.From.Y != 1 || fromTo.To.Y != 3)
			return new InvalidMovePath(fromTo);

		return this.verticalMoveStrategy.GetMovePath(fromTo);
	}
}
