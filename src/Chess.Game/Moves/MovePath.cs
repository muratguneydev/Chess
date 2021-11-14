namespace Chess.Game;

public class MovePath
{
	public MovePath(Move move, IEnumerable<Coordinate> coordinatesInPath)
	{
		Move = move;
		this.CoordinatesInPath = coordinatesInPath;
	}

	public Move Move { get; }
	public IEnumerable<Coordinate> CoordinatesInPath { get; }
	public bool IsValid => !(this is InvalidMovePath);
}

public class InvalidMovePath : MovePath
{
	public InvalidMovePath(Move fromTo)
		: base(fromTo, Enumerable.Empty<Coordinate>())
	{
	}
}