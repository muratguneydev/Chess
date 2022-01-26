using System.Collections;

namespace Chess.Game;

public class MovePath : IEnumerable<Coordinate>
{
	private readonly IEnumerable<Coordinate> coordinatesInPath;

	public MovePath(Move move, IEnumerable<Coordinate> coordinatesInPath, IMoveStrategy strategy)
	{
		this.Move = move;
		this.coordinatesInPath = coordinatesInPath;
		this.Strategy = strategy;
		//this.CoordinatesInPath = coordinatesInPath;
	}

	public Move Move { get; }
	public IMoveStrategy Strategy { get; }
	//public IEnumerable<Coordinate> CoordinatesInPath { get; }
	public bool IsValid => !(this is InvalidMovePath);
	public bool IsEnPassant => this.Strategy is EnPassantMoveStrategy;


	public IEnumerator<Coordinate> GetEnumerator()
	{
		return this.coordinatesInPath.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}