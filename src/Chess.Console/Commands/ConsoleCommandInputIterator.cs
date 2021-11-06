using System.Collections;

namespace Chess.Console;

public class ConsoleCommandInputIterator : IEnumerator<ChessCommand>
{
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private BoardViewModel boardViewModel;

	private bool exitRequested;

	public ConsoleCommandInputIterator(ConsoleWriterFactory consoleWriterFactory, BoardViewModel boardViewModel)
	{
		this.consoleWriterFactory = consoleWriterFactory;
		this.boardViewModel = boardViewModel;
	}

	public ChessCommand Current => this.GetCommand();

	object IEnumerator.Current => this.Current;

	public void UpdateBoardInformation(BoardViewModel boardViewModel)
	{
		this.boardViewModel = boardViewModel;
	}

	public void Dispose()
	{
		
	}

	public bool MoveNext()
	{
		return !exitRequested;
	}

	public void Reset()
	{
		
	}

	private ChessCommand GetCommand()
	{
		var moveString = System.Console.ReadLine();
		if (string.IsNullOrWhiteSpace(moveString))
		{
			this.exitRequested = true;
			return new ExitCommand(this.consoleWriterFactory);
		}

		return new MoveCommand(this.consoleWriterFactory, this.boardViewModel, moveString);
	}
}
