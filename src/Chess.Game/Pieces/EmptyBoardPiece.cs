namespace Chess.Game;

public record EmptyBoardPiece : BoardPieceDecorator
{
	public EmptyBoardPiece(Board board)
		: base(EmptyPiece.Piece, board, new CellHistory(board))
	{
	}

	public override Color Color => Color.None;
}
