namespace Chess.Game;

public class WhiteEnPassantMoveStrategy : EnPassantMoveStrategy
{
	public WhiteEnPassantMoveStrategy(Board board) : base(board, new WhiteYDirection())
	{
	}
}
