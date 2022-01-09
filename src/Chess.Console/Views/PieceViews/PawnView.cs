namespace Chess.Console;

public class PawnView : BoardPieceView
{
	public PawnView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(boardPieceViewModel, consoleWriterFactory)
	{
	}

	protected override string DisplayString => "P";
}
