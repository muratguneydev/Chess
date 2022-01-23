namespace Chess.Game;

public record WhitePawn : Pawn
{
	public WhitePawn(Board board)
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
					new WhiteEnPassantMoveStrategy(board) as IMoveStrategy
				}))
		)
	{
		
	}

}
