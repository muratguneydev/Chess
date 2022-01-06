namespace Chess.Game;

public class LShapeMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(Move fromTo)
	{
		if (
			TwoUpOneRight(fromTo)
			|| TwoUpOneLeft(fromTo)
			|| OneUpTwoRight(fromTo)
			|| OneUpTwoLeft(fromTo)
			|| TwoDownOneRight(fromTo)
			|| TwoDownOneLeft(fromTo)
			|| OneDownTwoRight(fromTo)
			|| OneDownTwoLeft(fromTo)
		)
		{
			return new MovePath(fromTo, Enumerable.Empty<Coordinate>(), this);
		}

		return new InvalidMovePath(fromTo);
	}

	private static bool TwoUpOneRight(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 1 && fromTo.To.Y == fromTo.From.Y + 2;
	}

	private static bool TwoUpOneLeft(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 1 && fromTo.To.Y == fromTo.From.Y + 2;
	}

	private static bool OneUpTwoRight(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 2 && fromTo.To.Y == fromTo.From.Y + 1;
	}

	private static bool OneUpTwoLeft(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 2 && fromTo.To.Y == fromTo.From.Y + 1;
	}

	private static bool TwoDownOneRight(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 1 && fromTo.To.Y == fromTo.From.Y - 2;
	}

	private static bool TwoDownOneLeft(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 1 && fromTo.To.Y == fromTo.From.Y - 2;
	}

	private static bool OneDownTwoRight(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 2 && fromTo.To.Y == fromTo.From.Y - 1;
	}

	private static bool OneDownTwoLeft(Move fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 2 && fromTo.To.Y == fromTo.From.Y - 1;
	}
}
