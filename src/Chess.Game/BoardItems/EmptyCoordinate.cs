namespace Chess.Game;

public record EmptyCoordinate : Coordinate
{
	private static EmptyCoordinate emptyCoordinate = new EmptyCoordinate();

	private EmptyCoordinate()
		: base(-1, -1)
	{
	}

	public static EmptyCoordinate Coordinate => emptyCoordinate;

	protected override void ValidateCoordinate(int coordinatePart, string coordinateName)
	{
		//no-op
	}
}