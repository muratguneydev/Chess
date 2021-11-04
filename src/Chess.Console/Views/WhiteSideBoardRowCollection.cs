using System.Collections;

namespace Chess.Console;

public class WhiteSideBoardRowCollection : IEnumerable<BoardRowView>
{
	private readonly BoardViewModel boardViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly BoardCellViewModel[,] matrix;

	public WhiteSideBoardRowCollection(BoardViewModel boardViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.boardViewModel = boardViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
		this.matrix = boardViewModel.BoardCellViewModelTable;
	}

	public IEnumerator<BoardRowView> GetEnumerator()
	{
		var rowSize = this.matrix.GetLength(0);//8
		for (int row = 0; row < this.matrix.GetLength(0); row++)
		{
			var rowNumber = rowSize - row - 1;
			yield return new BoardRowView(rowNumber, this.GetRowCells(rowNumber), this.consoleWriterFactory.Get());
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	private IEnumerable<BoardCellView> GetRowCells(int row)
	{
		var columnSize = this.matrix.GetLength(1);//8
		for (int column = 0; column < columnSize; column++)
		{
			yield return new BoardCellView(matrix[column, row], this.consoleWriterFactory);
		}
	}
}
