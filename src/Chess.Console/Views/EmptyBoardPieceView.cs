namespace Chess.Console;

public class EmptyBoardPieceView : BoardPieceView
{
	private readonly BoardPieceViewModel boardPieceViewModel;

	public EmptyBoardPieceView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
		this.boardPieceViewModel = boardPieceViewModel;
	}

	protected override string DisplayString => "_";
}
