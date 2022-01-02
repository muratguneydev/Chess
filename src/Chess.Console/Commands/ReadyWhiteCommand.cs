using Chess.Game;

namespace Chess.Console;

public class ReadyWhiteCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public ReadyWhiteCommand(ConsoleWriterFactory consoleWriterFactory)
	{
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override View Execute(Session session)
	{
		session.SetWhitePlayerReady();
		return new InformationView(new InformationViewModel($"White player ready."), this.consoleWriterFactory);
	}
}
