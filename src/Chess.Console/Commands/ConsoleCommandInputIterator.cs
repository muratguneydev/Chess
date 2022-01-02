using System.Collections;

namespace Chess.Console;

public class ConsoleCommandInputIterator : IEnumerator<ChessCommand>
{
	private readonly IConsoleReader consoleReader;
	private readonly CommandFactory commandFactory;
	private bool exitRequested;

	public ConsoleCommandInputIterator(IConsoleReader consoleReader, CommandFactory commandFactory)
	{
		this.consoleReader = consoleReader;
		this.commandFactory = commandFactory;
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
		var commandString = this.consoleReader.ReadLine().Trim();
		this.exitRequested = string.IsNullOrWhiteSpace(commandString);

		return this.commandFactory.Get(commandString);
	}
}