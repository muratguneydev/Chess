using Chess.Game;

namespace Chess.Console;

class Program
{
	private static readonly ConsoleWriterFactory consoleWriterFactory = new ConsoleWriterFactory();
	private static readonly IConsoleReader consoleReader = new ConsoleReader();
	private static Session session;
	private static Board board;

	static Program()
	{
		board = new Board();
		board.SetOpeningPosition();
		session = GetNewSession();
	}
	static void Main(string[] args)
	{
		var boardViewModel = new BoardViewModel(board);
		DisplayFromWhiteSide(boardViewModel, session);
		ProcessCommands(session, boardViewModel);
	}

	private static void ProcessCommands(Session session, BoardViewModel boardViewModel)
	{
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReader, consoleWriterFactory, boardViewModel);
		foreach (var command in consoleCommandInputProducer)
		{
			command.Execute(session).Display();
			DisplayFromWhiteSide(boardViewModel, session);
			foreach (var item in session.MoveHistory)
			{
				new ValidMoveView(new MoveViewModel(item), boardViewModel, consoleWriterFactory).Display();
			}
			consoleWriterFactory.Get().WriteLine(session.CurrentState.ToString());
		}
	}

	private static Session GetNewSession()
	{
		var sessionPlayerRegistrar = new SessionPlayerRegistrar();
		sessionPlayerRegistrar.AddPlayersRegisteredEventCallback(AllPlayersRegisteredHandler);
		var sessionPlayers = new SessionPlayers(sessionPlayerRegistrar);
		sessionPlayers.AddPlayersReadyEventCallback(AllPlayersReadyHandler);
		return new Session(sessionPlayers, sessionPlayerRegistrar, new SessionStateMachine(), board, new MoveHistory(board));
	}

	public static void AllPlayersRegisteredHandler(SessionPlayerRegistrar sessionPlayerRegistrar)
	{

	}

	public static void AllPlayersReadyHandler(SessionPlayers sessionPlayers)
	{
		session.Start();
	}

	private static void DisplayFromWhiteSide(BoardViewModel boardViewModel, Session session)
	{
		new PlayerView(new PlayerViewModel(session.BlackPlayer), consoleWriterFactory).Display();
		new BoardWhiteSideView(new WhiteSideBoardRowCollection(boardViewModel, consoleWriterFactory), consoleWriterFactory).Display();
		new PlayerView(new PlayerViewModel(session.WhitePlayer), consoleWriterFactory).Display();
	}

	private static void DisplayFromBlackSide(BoardViewModel boardViewModel, Session session)
	{
		new PlayerView(new PlayerViewModel(session.WhitePlayer), consoleWriterFactory).Display();
		new BoardBlackSideView(new BlackSideBoardRowCollection(boardViewModel, consoleWriterFactory), consoleWriterFactory).Display();
		new PlayerView(new PlayerViewModel(session.BlackPlayer), consoleWriterFactory).Display();
	}

}
