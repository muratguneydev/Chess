namespace Chess.Game;

public record Coordinate
{
	public Coordinate(int x, int y)
	{
		this.ValidateCoordinate(x, nameof(x));
		this.ValidateCoordinate(y, nameof(y));

		this.X = x;
		this.Y = y;
	}

	public int X { get; }
	public int Y { get; }

	protected virtual void ValidateCoordinate(int coordinatePart, string coordinateName)
	{
		if (coordinatePart < 0 || coordinatePart > 7)
			throw new ArgumentException($"{coordinateName}:{coordinatePart} doesn't match the chessboard coordinate requirements 8x8.");
	}
}
