namespace Chess.Console;

public class KingView : BoardPieceView
{
	public KingView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
	}

	protected override string DisplayString => "K";
}
