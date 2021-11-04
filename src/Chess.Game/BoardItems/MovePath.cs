namespace Chess.Game;

public class MovePath
{
	public MovePath(FromTo fromTo, IEnumerable<Coordinate> coordinatesInPath)
	{
		FromTo = fromTo;
		this.CoordinatesInPath = coordinatesInPath;
	}

	public FromTo FromTo { get; }
	public IEnumerable<Coordinate> CoordinatesInPath { get; }
	public bool IsValid => !(this is InvalidMovePath);
}

public class InvalidMovePath : MovePath
{
	public InvalidMovePath(FromTo fromTo)
		: base(fromTo, Enumerable.Empty<Coordinate>())
	{
	}
}