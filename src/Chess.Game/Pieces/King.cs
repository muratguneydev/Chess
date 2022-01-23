namespace Chess.Game;

public record King : Piece
{
	public King()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(
					new OneSquareMoveStrategy(
						new CompositeMoveStrategy(
							new[] { new HorizontalMoveStrategy(), new VerticalMoveStrategy(), new DiagonalMoveStrategy() as IMoveStrategy })))
		)
	{
		
	}
}
