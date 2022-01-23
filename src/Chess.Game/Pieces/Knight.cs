namespace Chess.Game;

public record Knight : Piece
{
	public Knight()
		: base(new LShapeMoveStrategy())
	{
		
	}
}