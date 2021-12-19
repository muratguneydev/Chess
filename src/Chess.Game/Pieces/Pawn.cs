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

public class BlackPawn : Pawn
{
	public BlackPawn(Board board)
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
					new BlackEnPassantMoveStrategy(board) as IMoveStrategy
				}))
		)
	{
		
	}

}