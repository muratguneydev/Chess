using System.Linq;

namespace Chess.Game.Tests;

public class TestMoveStrategy : IMoveStrategy
{
	public MovePath GetMovePath(FromTo fromTo)
	{
		return new MovePath(fromTo, Enumerable.Empty<Coordinate>());
	}
}
