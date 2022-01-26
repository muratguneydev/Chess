namespace Chess.Game;

public class WhiteEnPassantMoveStrategy : EnPassantMoveStrategy
{
	public WhiteEnPassantMoveStrategy() : base(new WhiteYDirection())
	{
	}
}
