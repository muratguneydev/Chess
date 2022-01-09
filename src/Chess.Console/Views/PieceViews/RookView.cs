namespace Chess.Console;

public class RookView : BoardPieceView
{
	public RookView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
	}

	protected override string DisplayString => "R";
}
