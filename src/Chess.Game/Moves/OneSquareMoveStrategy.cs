namespace Chess.Game;

public class OneSquareMoveStrategy : IMoveStrategy
{
	private readonly IMoveStrategy moveStrategy;

	public OneSquareMoveStrategy(IMoveStrategy moveStrategy)
	{
		this.moveStrategy = moveStrategy;
	}

	public MovePath GetMovePath(Move fromTo)
	{
		if (!OneSquareInAnyDirection(fromTo))
			return new InvalidMovePath(fromTo);

		return this.moveStrategy.GetMovePath(fromTo);
	}

	private static bool OneSquareInAnyDirection(Move fromTo)
	{
		return
			IsVerticalOneSquare(fromTo)
			|| IsHorizontalOneSquare(fromTo)
			|| IsDiagonalOneSquare(fromTo);
	}

	private static bool IsDiagonalOneSquare(Move fromTo)
	{
		return (CoordinateDiffIsOneSquare(fromTo.From.X, fromTo.To.X) && CoordinateDiffIsOneSquare(fromTo.From.Y, fromTo.To.Y));
	}

	private static bool IsHorizontalOneSquare(Move fromTo)
	{
		return (fromTo.IsOnSameRow && CoordinateDiffIsOneSquare(fromTo.From.X, fromTo.To.X));
	}

	private static bool IsVerticalOneSquare(Move fromTo)
	{
		return (fromTo.IsOnSameColumn && CoordinateDiffIsOneSquare(fromTo.From.Y, fromTo.To.Y));
	}

	private static bool CoordinateDiffIsOneSquare(int coordinatePartOne, int coordinatePart2)
	{
		return Math.Abs(coordinatePartOne - coordinatePart2) == 1;
	}
}