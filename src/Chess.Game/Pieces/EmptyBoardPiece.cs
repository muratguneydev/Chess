namespace Chess.Game;

// public record EmptyBoardPiece : BoardPieceDecorator
// {
// 	public EmptyBoardPiece()
// 		: base(EmptyPiece.Piece, new CellHistory())
// 	{
// 	}

// 	public override Color Color => Color.None;
// }

public record EmptyBoardPiece : BoardPieceDecorator
{
	private static EmptyBoardPiece emptyBoardPiece = new EmptyBoardPiece();

	private EmptyBoardPiece()
		: base(EmptyPiece.Piece, new CellHistory())
	{
	}

	public static EmptyBoardPiece BoardPiece => emptyBoardPiece;

	public override Color Color => Color.None;
}