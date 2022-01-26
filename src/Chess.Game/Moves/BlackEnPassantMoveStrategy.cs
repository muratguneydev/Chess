namespace Chess.Game;

public class BlackEnPassantMoveStrategy : EnPassantMoveStrategy
{
	public BlackEnPassantMoveStrategy() : base(new BlackYDirection())
	{
	}
}