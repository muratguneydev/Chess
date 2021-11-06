using Chess.Game;

namespace Chess.Console;

public abstract class ChessCommand
{
	public abstract View Execute(Session session);
}
