using System.Linq;

namespace Chess.Game.Tests;

public class TestMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(Move move)
	{
		return new MovePath(move, Enumerable.Empty<Coordinate>(), new EmptyMoveStrategy());
	}
}
