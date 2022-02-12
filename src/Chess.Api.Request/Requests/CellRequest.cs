namespace Chess.Api.Request;

public record CellRequest
{
	public CellRequest(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}

	public int X { get; }
	public int Y { get; }
}
