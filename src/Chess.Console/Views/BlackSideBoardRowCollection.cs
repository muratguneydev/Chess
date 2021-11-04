using System.Collections;

namespace Chess.Console;

public class BlackSideBoardRowCollection : IEnumerable<BoardRowView>
{
	private readonly BoardViewModel boardViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly BoardCellViewModel[,] matrix;

	public BlackSideBoardRowCollection(BoardViewModel boardViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.boardViewModel = boardViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
		this.matrix = boardViewModel.BoardCellViewModelTable;
	}

	public IEnumerator<BoardRowView> GetEnumerator()
	{
		for (int row = 0; row < this.matrix.GetLength(0); row++)
		{
			yield return new BoardRowView(row, this.GetRowCells(row), this.consoleWriterFactory.Get());
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
			yield return new BoardCellView(matrix[columnSize - column - 1, row], this.consoleWriterFactory);
		}
	}
}
