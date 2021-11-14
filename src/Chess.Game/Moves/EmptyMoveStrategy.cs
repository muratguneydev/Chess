namespace Chess.Game;

public class EmptyMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(Move fromTo)
	{
		return new InvalidMovePath(fromTo);
	}
}