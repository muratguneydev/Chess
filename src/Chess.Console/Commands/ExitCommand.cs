using Chess.Game;

namespace Chess.Console;

public class ExitCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public ExitCommand(ConsoleWriterFactory consoleWriterFactory)
	{
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override View Execute(Session session)
	{
		return new InformationView(new InformationViewModel("Exiting..."), this.consoleWriterFactory);
	}
}
