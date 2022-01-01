using Chess.Game;

namespace Chess.Console;

public class RegisterBlackCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly string name;

	public RegisterBlackCommand(ConsoleWriterFactory consoleWriterFactory, string name)
	{
		this.consoleWriterFactory = consoleWriterFactory;
		this.name = name;
	}

	public override View Execute(Session session)
	{
		var blackPlayer = new BlackPlayer(new Clock(new TimerWrapper()), this.name);
		session.RegisterBlackPlayer(blackPlayer);
		return new InformationView(new InformationViewModel($"Black player {this.name} registered."), this.consoleWriterFactory);
	}
}
