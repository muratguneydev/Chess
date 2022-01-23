namespace Chess.Game;

public record Bishop : Piece
{
	public Bishop()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(new DiagonalMoveStrategy()))
	{
		
	}
}