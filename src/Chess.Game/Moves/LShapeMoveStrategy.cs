namespace Chess.Game;

public class LShapeMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(FromTo fromTo)
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
			return new MovePath(fromTo, Enumerable.Empty<Coordinate>());
		}

		return new InvalidMovePath(fromTo);
	}

	private static bool TwoUpOneRight(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 1 && fromTo.To.Y == fromTo.From.Y + 2;
	}

	private static bool TwoUpOneLeft(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 1 && fromTo.To.Y == fromTo.From.Y + 2;
	}

	private static bool OneUpTwoRight(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 2 && fromTo.To.Y == fromTo.From.Y + 1;
	}

	private static bool OneUpTwoLeft(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 2 && fromTo.To.Y == fromTo.From.Y + 1;
	}

	private static bool TwoDownOneRight(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 1 && fromTo.To.Y == fromTo.From.Y - 2;
	}

	private static bool TwoDownOneLeft(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 1 && fromTo.To.Y == fromTo.From.Y - 2;
	}

	private static bool OneDownTwoRight(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X + 2 && fromTo.To.Y == fromTo.From.Y - 1;
	}

	private static bool OneDownTwoLeft(FromTo fromTo)
	{
		return fromTo.To.X == fromTo.From.X - 2 && fromTo.To.Y == fromTo.From.Y - 1;
	}
}
