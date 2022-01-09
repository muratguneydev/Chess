namespace Chess.Console;

public class BoardCellView : View
{
	private readonly BoardCellViewModel boardCellViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public BoardCellView(BoardCellViewModel boardCellViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.boardCellViewModel = boardCellViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override void Display()
	{
		var boardPieceViewModel = this.boardCellViewModel.BoardPieceViewModel;
		boardPieceViewModel.GetBoardPieceView(this.consoleWriterFactory).Display();
	}
}
