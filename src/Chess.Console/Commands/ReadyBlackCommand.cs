using Chess.Game;

namespace Chess.Console;

public class ReadyBlackCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public ReadyBlackCommand(ConsoleWriterFactory consoleWriterFactory)
	{
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override View Execute(Session session)
	{
		session.SetBlackPlayerReady();
		return new InformationView(new InformationViewModel($"Black player ready."), this.consoleWriterFactory);
	}
}