namespace Chess.Console;

public class CommandFactory
{
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly BoardViewModel boardViewModel;
	private Dictionary<string, Func<ConsoleWriterFactory, BoardViewModel, string, ChessCommand>> commandMap = new Dictionary<string, Func<ConsoleWriterFactory, BoardViewModel, string, ChessCommand>>();

	public CommandFactory(ConsoleWriterFactory consoleWriterFactory, BoardViewModel boardViewModel)
	{
		this.consoleWriterFactory = consoleWriterFactory;
		this.boardViewModel = boardViewModel;
		this.PopulateCommandMap();
	}

	public ChessCommand Get(string commandString)
	{
		var argumentArray = commandString.Split(":");
		var command = argumentArray[0];
		var arguments = argumentArray.Length < 2 ? string.Empty : argumentArray[1];

		return this.commandMap.ContainsKey(command)
			? this.commandMap[command](this.consoleWriterFactory, this.boardViewModel, arguments)
			: new InvalidCommand(this.consoleWriterFactory, commandString);
	}

	private void PopulateCommandMap()
	{
		this.commandMap = new Dictionary<string, Func<ConsoleWriterFactory, BoardViewModel, string, ChessCommand>>
		{
			{ "", (consoleWriterFactory, boardViewModel, parameter) => new ExitCommand(consoleWriterFactory) },
			{ "anonymous", (consoleWriterFactory, boardViewModel, parameter) => new RegisterAnonymousCommand(consoleWriterFactory) },
			{ "back", (consoleWriterFactory, boardViewModel, parameter) => new TakeBackCommand(consoleWriterFactory, boardViewModel)},
			{ "registerblack", (consoleWriterFactory, boardViewModel, parameter) => new RegisterBlackCommand(consoleWriterFactory, parameter)},
			{ "registerwhite", (consoleWriterFactory, boardViewModel, parameter) => new RegisterWhiteCommand(consoleWriterFactory, parameter)},
			{ "readyblack", (consoleWriterFactory, boardViewModel, parameter) => new ReadyBlackCommand(consoleWriterFactory)},
			{ "readywhite", (consoleWriterFactory, boardViewModel, parameter) => new ReadyWhiteCommand(consoleWriterFactory)},
			{ "move", (consoleWriterFactory, boardViewModel, parameter) => new MoveCommand(consoleWriterFactory, boardViewModel, parameter)},
		};
	}
}
