namespace Chess.Game;

public class Queen : Piece
{
	public Queen()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(
				new CompositeMoveStrategy(new[] { new HorizontalMoveStrategy(), new VerticalMoveStrategy(), new DiagonalMoveStrategy() as IMoveStrategy })))
	{
		
	}
}
