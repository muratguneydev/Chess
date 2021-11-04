namespace Chess.Console;

public class BoardBlackSideView : View
{
	private readonly BlackSideBoardRowCollection boardRows;
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public BoardBlackSideView(BlackSideBoardRowCollection boardRows, ConsoleWriterFactory consoleWriterFactory)
	{
		this.boardRows = boardRows;
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override void Display()
	{
		this.WriteHeaderRow();

		foreach (var boardRow in this.boardRows)
		{
			DisplayBoardRow(boardRow);
			this.consoleWriterFactory.Get().WriteLine();
		}

		this.WriteHeaderRow();
	}

	private void DisplayBoardRow(BoardRowView boardRow)
	{
		this.WriteBoardNumber(boardRow);
		boardRow.Display();
		this.WriteBoardNumber(boardRow);
	}

	private void WriteHeaderRow()
	{
		this.consoleWriterFactory
			.Get(ConsoleColor.Black, ConsoleColor.Green)
			.WriteLineWithSeparatorPrefix(new[] { "h", "g", "f", "e", "d", "c", "b", "a" });
	}

	private void WriteBoardNumber(BoardRowView boardRow)
	{
		this.consoleWriterFactory
			.Get(ConsoleColor.Black, ConsoleColor.Yellow)
			.WriteWithSeparatorPostfix(boardRow.RowNumber.ToString());
	}
}
