namespace Chess.Game;

public class MovePath
{
	public MovePath(Move move, IEnumerable<Coordinate> coordinatesInPath, IMoveStrategy strategy)
	{
		this.Move = move;
		this.Strategy = strategy;
		this.CoordinatesInPath = coordinatesInPath;
	}

	public Move Move { get; }
	public IMoveStrategy Strategy { get; }
	public IEnumerable<Coordinate> CoordinatesInPath { get; }
	public bool IsValid => !(this is InvalidMovePath);
	public bool IsEnPassant => this.Strategy is EnPassantMoveStrategy;
}