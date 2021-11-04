namespace Chess.Game;

public class HorizontalMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(FromTo fromTo)
	{
		if (!fromTo.IsOnSameRow)
			return new InvalidMovePath(fromTo);

		return new MovePath(fromTo, GetHorizontalCoordinatesOnSameY(fromTo));
	}

	private static IEnumerable<Coordinate> GetHorizontalCoordinatesOnSameY(FromTo fromTo)
	{
		// return Enumerable
		// 	.Range(fromTo.LowestRow+1,fromTo.HighestRow-fromTo.LowestRow-1)
		// 	.Select(x => new Coordinate(x, fromTo.From.Y));

		for (var x = fromTo.LowestColumn+1; x < fromTo.HighestColumn; x++)
		{
			yield return new Coordinate(x, fromTo.From.Y);
		}
	}
}
