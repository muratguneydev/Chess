using System.Collections;

namespace Chess.Console;

public class ConsoleCommandInputIterator : IEnumerator<ChessCommand>
{
	private readonly IConsoleReader consoleReader;
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private BoardViewModel boardViewModel;

	private bool exitRequested;

	public ConsoleCommandInputIterator(IConsoleReader consoleReader, ConsoleWriterFactory consoleWriterFactory,
		BoardViewModel boardViewModel)
	{
		this.consoleReader = consoleReader;
		this.consoleWriterFactory = consoleWriterFactory;
		this.boardViewModel = boardViewModel;
	}

	public ChessCommand Current => this.GetCommand();

	object IEnumerator.Current => this.Current;

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
		var moveString = this.consoleReader.ReadLine();
		if (string.IsNullOrWhiteSpace(moveString))
		{
			this.exitRequested = true;
			return new ExitCommand(this.consoleWriterFactory);
		}

		if (moveString == "back")
			return new TakeBackCommand(this.consoleWriterFactory, this.boardViewModel);

		return new MoveCommand(this.consoleWriterFactory, this.boardViewModel, moveString);
	}
}
