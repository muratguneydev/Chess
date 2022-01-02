using Chess.Game;

namespace Chess.Console;

public class RegisterAnonymousCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public RegisterAnonymousCommand(ConsoleWriterFactory consoleWriterFactory)
	{
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override View Execute(Session session)
	{
		var blackPlayer = new BlackPlayer(new Clock(new TimerWrapper()), "Player Black");
		session.RegisterBlackPlayer(blackPlayer);

		var whitePlayer = new WhitePlayer(new Clock(new TimerWrapper()), "Player White");
		session.RegisterWhitePlayer(whitePlayer);

		new ReadyBlackCommand(consoleWriterFactory).Execute(session);
		new ReadyWhiteCommand(consoleWriterFactory).Execute(session);

		return new InformationView(new InformationViewModel($"Black and white players registered anonymously."), this.consoleWriterFactory);
	}
}
