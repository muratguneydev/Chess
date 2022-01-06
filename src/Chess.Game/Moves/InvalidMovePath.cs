namespace Chess.Game;

public class InvalidMovePath : MovePath
{
	public InvalidMovePath(Move move)
		: base(move, Enumerable.Empty<Coordinate>(), new EmptyMoveStrategy())
	{
	}
}