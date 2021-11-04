namespace Chess.Game;

public class Rook : Piece
{
	public Rook()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(
			new CompositeMoveStrategy(new[] { new HorizontalMoveStrategy(), new VerticalMoveStrategy() as IMoveStrategy })))
	{
		
	}
}
