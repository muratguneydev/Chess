namespace Chess.Console;

public class BishopView : BoardPieceView
{
	public BishopView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
	}

	protected override string DisplayString => "B";
}