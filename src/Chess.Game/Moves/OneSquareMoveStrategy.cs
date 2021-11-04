namespace Chess.Game;

public class OneSquareMoveStrategy : IMoveStrategy
{
	private readonly IMoveStrategy moveStrategy;

	public OneSquareMoveStrategy(IMoveStrategy moveStrategy)
	{
		this.moveStrategy = moveStrategy;
	}

	public MovePath GetMovePath(FromTo fromTo)
	{
		if (!OneSquareInAnyDirection(fromTo))
			return new InvalidMovePath(fromTo);

		return this.moveStrategy.GetMovePath(fromTo);
	}

	private static bool OneSquareInAnyDirection(FromTo fromTo)
	{
		return
			IsVerticalOneSquare(fromTo)
			|| IsHorizontalOneSquare(fromTo)
			|| IsDiagonalOneSquare(fromTo);
	}

	private static bool IsDiagonalOneSquare(FromTo fromTo)
	{
		return (CoordinateDiffIsOneSquare(fromTo.From.X, fromTo.To.X) && CoordinateDiffIsOneSquare(fromTo.From.Y, fromTo.To.Y));
	}

	private static bool IsHorizontalOneSquare(FromTo fromTo)
	{
		return (fromTo.IsOnSameRow && CoordinateDiffIsOneSquare(fromTo.From.X, fromTo.To.X));
	}

	private static bool IsVerticalOneSquare(FromTo fromTo)
	{
		return (fromTo.IsOnSameColumn && CoordinateDiffIsOneSquare(fromTo.From.Y, fromTo.To.Y));
	}

	private static bool CoordinateDiffIsOneSquare(int coordinatePartOne, int coordinatePart2)
	{
		return Math.Abs(coordinatePartOne - coordinatePart2) == 1;
	}
}