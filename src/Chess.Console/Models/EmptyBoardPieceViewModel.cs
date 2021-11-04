using Chess.Game;

namespace Chess.Console;

public class EmptyBoardPieceViewModel : BoardPieceViewModel
{
	private static EmptyBoardPieceViewModel emptyBoardPieceViewModel = new EmptyBoardPieceViewModel();

	private EmptyBoardPieceViewModel()
		: base(EmptyBoardPiece.Piece)
	{
	}

	public override Color Color => Color.None;

	public static EmptyBoardPieceViewModel BoardPieceViewModel => emptyBoardPieceViewModel;
}