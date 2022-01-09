namespace Chess.Console;

public class QueenView : BoardPieceView
{
	public QueenView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
	}

	protected override string DisplayString => "Q";
}
