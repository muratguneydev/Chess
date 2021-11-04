namespace Chess.Game;

public class Knight : Piece
{
	public Knight()
		: base(new LShapeMoveStrategy())
	{
		
	}
}