namespace Chess.Game;

public interface IMoveStrategy
{
	MovePath GetMovePath(FromTo fromTo);
	
}
