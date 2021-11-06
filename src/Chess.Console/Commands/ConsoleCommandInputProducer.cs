using System.Collections;

namespace Chess.Console;

public class ConsoleCommandInputProducer : IEnumerable<ChessCommand>
{
	private readonly ConsoleCommandInputIterator consoleCommandInputIterator;

	public ConsoleCommandInputProducer(IConsoleReader consoleReader, ConsoleWriterFactory consoleWriterFactory,
		BoardViewModel boardViewModel)
	{
		this.consoleCommandInputIterator = new ConsoleCommandInputIterator(consoleReader, consoleWriterFactory, boardViewModel);
	}

	public IEnumerator<ChessCommand> GetEnumerator()
	{
		return this.consoleCommandInputIterator;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.consoleCommandInputIterator;
	}
}