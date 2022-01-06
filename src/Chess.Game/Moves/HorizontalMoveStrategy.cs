namespace Chess.Game;

public class HorizontalMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(Move move)
	{
		if (!move.IsOnSameRow)
			return new InvalidMovePath(move);

		return new MovePath(move, GetHorizontalCoordinatesOnSameY(move), this);
	}

	private static IEnumerable<Coordinate> GetHorizontalCoordinatesOnSameY(Move fromTo)
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
