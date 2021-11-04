namespace Chess.Game;

public abstract class Pawn : Piece
{
	public Pawn(IMoveStrategy moveStrategy)
		: base(moveStrategy)
	{
		
	}

}


public class WhitePawn : Pawn
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
								new DiagonalMoveStrategy()))) as IMoveStrategy
				}))
		)
	{
		
	}

}

public class BlackPawn : Pawn
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
								new DiagonalMoveStrategy()))) as IMoveStrategy
				}))
		)
	{
		
	}

}