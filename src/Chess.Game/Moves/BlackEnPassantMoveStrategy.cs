namespace Chess.Game;

public class BlackEnPassantMoveStrategy : EnPassantMoveStrategy
{
	public BlackEnPassantMoveStrategy(Board board) : base(board, new BlackYDirection())
	{
	}
}