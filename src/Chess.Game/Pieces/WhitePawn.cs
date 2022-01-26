namespace Chess.Game;

public record WhitePawn : Pawn
{
	public WhitePawn()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(
			new CompositeMoveStrategy(new[] {
					new WhiteTwoVerticalSquaresInitialMoveStrategy(
						new VerticalMoveStrategy()),
					new WhiteForwardOnlyMoveStrategy(
						new OneSquareMoveStrategy(
							new VerticalMoveStrategy())),
					new WhiteForwardOnlyMoveStrategy(
						new OnlyAttackMoveStrategy(
							new OneSquareMoveStrategy(
								new DiagonalMoveStrategy()))),
					new WhiteEnPassantMoveStrategy() as IMoveStrategy
				}))
		)
	{
		
	}

}
