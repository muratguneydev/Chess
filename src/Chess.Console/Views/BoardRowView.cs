namespace Chess.Console;

public class BoardRowView : View
{
	private readonly IEnumerable<BoardCellView> rowCells;
	private readonly IConsoleWriter consoleWriter;

	public BoardRowView(int rowNumber, IEnumerable<BoardCellView> rowCells, IConsoleWriter consoleWriter)
	{
		this.RowNumber = rowNumber+1;
		this.rowCells = rowCells;
		this.consoleWriter = consoleWriter;
	}

	public int RowNumber { get; }

	public override void Display()
	{
		foreach (var cell in this.rowCells)
		{
			cell.Display();
			this.consoleWriter.WriteSeparator();
		}
	}
}
