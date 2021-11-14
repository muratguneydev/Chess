namespace Chess.Game;

public interface IMoveStrategy
{
	MovePath GetMovePath(Move fromTo);
	
}
