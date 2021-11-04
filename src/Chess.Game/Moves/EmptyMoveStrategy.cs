namespace Chess.Game;

public class EmptyMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(FromTo fromTo)
	{
		return new InvalidMovePath(fromTo);
	}
}