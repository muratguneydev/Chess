namespace Chess.Console;

public class KnightView : BoardPieceView
{
	public KnightView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
	}

	protected override string DisplayString => "T";
}
