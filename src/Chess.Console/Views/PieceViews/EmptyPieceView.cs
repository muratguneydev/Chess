namespace Chess.Console;

public class EmptyPieceView : BoardPieceView
{
	public EmptyPieceView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
	}

	protected override string DisplayString => "_";
}
