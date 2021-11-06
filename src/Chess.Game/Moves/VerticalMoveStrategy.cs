namespace Chess.Game;

public class VerticalMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(FromTo fromTo)
	{
		if (!fromTo.IsOnSameColumn)
			return new InvalidMovePath(fromTo);

		return new MovePath(fromTo, GetVerticalCoordinatesOnSameX(fromTo));
	}

	private static IEnumerable<Coordinate> GetVerticalCoordinatesOnSameX(FromTo fromTo)
	{
		for (var y = fromTo.LowestRow+1; y < fromTo.HighestRow; y++)
		{
			yield return new Coordinate(fromTo.From.X, y);
		}
	}
}