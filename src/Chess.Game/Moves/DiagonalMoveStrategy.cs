namespace Chess.Game;

public class DiagonalMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(Move fromTo)
	{
		if (Math.Abs(GetYDifference(fromTo)) != Math.Abs(GetXDifference(fromTo)))
			return new InvalidMovePath(fromTo);
		
		return new MovePath(fromTo, GetDiagonalCoordinates(fromTo), this);
	}

	private static IEnumerable<Coordinate> GetDiagonalCoordinates(Move fromTo)
	{
		var diffX = GetXDifference(fromTo);
		var diffY = GetYDifference(fromTo);
		var currentX = fromTo.From.X;
		var currentY = fromTo.From.Y;
		var directionX = diffX > 0 ? 1 : -1;
		var directionY = diffY > 0 ? 1 : -1;

		for (var i=1;i < Math.Abs(diffY);i++)
		{
			yield return new Coordinate(currentX+(i*directionX), currentY+(i*directionY));
		}
	}

	private static int GetXDifference(Move fromTo)
	{
		return fromTo.To.X - fromTo.From.X;
	}

	private static int GetYDifference(Move fromTo)
	{
		return fromTo.To.Y - fromTo.From.Y;
	}
}