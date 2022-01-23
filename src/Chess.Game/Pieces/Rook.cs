namespace Chess.Game;

public record Rook : Piece
{
	public Rook()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(
			new CompositeMoveStrategy(new[] { new HorizontalMoveStrategy(), new VerticalMoveStrategy() as IMoveStrategy })))
	{
		
	}
}
