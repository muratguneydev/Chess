using Chess.Game;

namespace Chess.Console;

class Program
{
	private static readonly ConsoleWriterFactory consoleWriterFactory = new ConsoleWriterFactory();
	private static readonly IConsoleReader consoleReader = new ConsoleReader();
	static void Main(string[] args)
	{
		using (var whiteClock = new Clock(new TimerWrapper()))
		{
			using (var blackClock = new Clock(new TimerWrapper()))
			{
				//TestClass.BlackPawnShouldBeAbleToAttack(board => new FromTo(board.b7, board.a6));	
				var session = GetSession(whiteClock, blackClock);
				var boardViewModel = GetBoardViewModel(session);
				DisplayFromWhiteSide(boardViewModel);
				session.Start();
				ProcessCommands(session, boardViewModel);
			}
		}
	}

	private static void ProcessCommands(Session session, BoardViewModel boardViewModel)
	{
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReader, consoleWriterFactory, boardViewModel);
		foreach (var command in consoleCommandInputProducer)
		{
			command.Execute(session).Display();
			DisplayFromWhiteSide(boardViewModel);
			foreach (var item in session.MoveHistory)
			{
				new ValidMoveView(new MoveViewModel(item), boardViewModel, consoleWriterFactory).Display();
			}
		}
	}

	private static BoardViewModel GetBoardViewModel(Session session)
	{
		var board = new Board(session);
		board.SetOpeningPosition();
		var boardViewModel = new BoardViewModel(board);
		return boardViewModel;
	}

	private static Session GetSession(IClock whiteClock, IClock blackClock)
	{
		var whitePlayer = new WhitePlayer(whiteClock);
		var blackPlayer = new BlackPlayer(blackClock);
		var session = new Session(whitePlayer, blackPlayer);
		return session;
	}

	private static void DisplayFromWhiteSide(BoardViewModel boardViewModel)
	{
		new BoardWhiteSideView(new WhiteSideBoardRowCollection(boardViewModel, consoleWriterFactory), consoleWriterFactory).Display();
	}

	private static void DisplayFromBlackSide(BoardViewModel boardViewModel)
	{
		new BoardBlackSideView(new BlackSideBoardRowCollection(boardViewModel, consoleWriterFactory), consoleWriterFactory).Display();
	}

}
