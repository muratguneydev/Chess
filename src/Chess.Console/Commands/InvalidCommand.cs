using Chess.Game;

namespace Chess.Console;

public class InvalidCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly string commandString;

	public InvalidCommand(ConsoleWriterFactory consoleWriterFactory, string commandString)
	{
		this.consoleWriterFactory = consoleWriterFactory;
		this.commandString = commandString;
	}

	public override View Execute(Session session)
	{
		return new ErrorView(new ErrorViewModel($"Invalid command '{this.commandString}'..."), this.consoleWriterFactory);
	}
}
