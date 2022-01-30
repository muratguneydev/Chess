using Chess.Game;

namespace Chess.Console;

public class RegisterWhiteCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly string name;

	public RegisterWhiteCommand(ConsoleWriterFactory consoleWriterFactory, string name)
	{
		this.consoleWriterFactory = consoleWriterFactory;
		this.name = name;
	}

	public override View Execute(Session session)
	{
		var whitePlayer = new WhitePlayer(new Clock(new DateTimeProvider()), this.name);
		session.RegisterWhitePlayer(whitePlayer);
		return new InformationView(new InformationViewModel($"White player {this.name} registered."), this.consoleWriterFactory);
	}
}
