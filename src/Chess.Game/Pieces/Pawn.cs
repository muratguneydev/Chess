namespace Chess.Game;

public abstract record Pawn : Piece
{
	public Pawn(IMoveStrategy moveStrategy)
		: base(moveStrategy)
	{
		
	}

}
