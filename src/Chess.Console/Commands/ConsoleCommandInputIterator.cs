using System.Collections;

namespace Chess.Console;

public class ConsoleCommandInputIterator : IEnumerator<ChessCommand>
{
	private readonly IConsoleReader consoleReader;
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private Dictionary<string, Func<ConsoleWriterFactory, BoardViewModel, string, ChessCommand>> commandFactory = new Dictionary<string, Func<ConsoleWriterFactory, BoardViewModel, string, ChessCommand>>();
	private BoardViewModel boardViewModel;

	private bool exitRequested;

	public ConsoleCommandInputIterator(IConsoleReader consoleReader, ConsoleWriterFactory consoleWriterFactory,
		BoardViewModel boardViewModel)
	{
		this.consoleReader = consoleReader;
		this.consoleWriterFactory = consoleWriterFactory;
		this.boardViewModel = boardViewModel;
		this.PopulateCommandFactory();
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
		var moveString = this.consoleReader.ReadLine().Trim();

		var argumentArray = moveString.Split(":");
		var command = argumentArray[0];
		var arguments = argumentArray.Length < 2 ? string.Empty : argumentArray[1];

		this.exitRequested = string.IsNullOrWhiteSpace(command);

		return commandFactory[command](this.consoleWriterFactory, this.boardViewModel, arguments);
	}

	private void PopulateCommandFactory()
	{
		this.commandFactory = new Dictionary<string, Func<ConsoleWriterFactory, BoardViewModel, string, ChessCommand>>
		{
			{ "", (consoleWriterFactory, boardViewModel, parameter) => new ExitCommand(consoleWriterFactory) },
			{ "anonymous", (consoleWriterFactory, boardViewModel, parameter) => new RegisterAnonymousCommand(consoleWriterFactory) },
			{ "back", (consoleWriterFactory, boardViewModel, parameter) => new TakeBackCommand(consoleWriterFactory, boardViewModel)},
			{ "registerblack", (consoleWriterFactory, boardViewModel, parameter) => new RegisterBlackCommand(consoleWriterFactory, parameter)},
			{ "registerwhite", (consoleWriterFactory, boardViewModel, parameter) => new RegisterWhiteCommand(consoleWriterFactory, parameter)},
			{ "move", (consoleWriterFactory, boardViewModel, parameter) => new MoveCommand(consoleWriterFactory, boardViewModel, parameter)},
		};
	}
//TODO: test/implement order of commands. ie. can't move before register/ready
//implement ready command.
//test all commands
	
}
