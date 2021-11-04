namespace Chess.Game;

public class Bishop : Piece
{
	public Bishop()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(new DiagonalMoveStrategy()))
	{
		
	}
}