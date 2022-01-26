namespace Chess.Game;

public record BlackPawn : Pawn
{
	public BlackPawn()
		: base(new CantMoveToTheCurrentCellStrategyDecorator(
			new CompositeMoveStrategy(new[] {
					new BlackTwoVerticalSquaresInitialMoveStrategy(
						new VerticalMoveStrategy()),
					new BlackForwardOnlyMoveStrategy(
						new OneSquareMoveStrategy(
							new VerticalMoveStrategy())),
					new BlackForwardOnlyMoveStrategy(
						new OnlyAttackMoveStrategy(
							new OneSquareMoveStrategy(
								new DiagonalMoveStrategy()))),
					new BlackEnPassantMoveStrategy() as IMoveStrategy
				}))
		)
	{
		
	}

}