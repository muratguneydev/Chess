using Chess.Game;

namespace Chess.Console;

public class BoardPieceViewModel
{
	private readonly IBoardPiece boardPiece;

	public BoardPieceViewModel(IBoardPiece boardPiece)
	{
		this.boardPiece = boardPiece;
	}

	public Type PieceType => this.boardPiece.PieceType;
	public virtual Color Color => this.boardPiece.Color;
}
