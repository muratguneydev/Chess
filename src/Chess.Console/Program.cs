using Chess.Game;

namespace Chess.Console;

class Program
{
	private static readonly ConsoleWriterFactory consoleWriterFactory = new ConsoleWriterFactory();
	private static readonly IConsoleReader consoleReader = new ConsoleReader();
	static void Main(string[] args)
	{
		//TestClass.BlackPawnShouldBeAbleToAttack(board => new FromTo(board.b7, board.a6));		

		var whitePlayer = new WhitePlayer();
		var blackPlayer = new BlackPlayer();
		var session = new Session(whitePlayer, blackPlayer);
		
		var board = new Board(session);
		board.SetOpeningPosition();
		var boardViewModel = new BoardViewModel(board);
		DisplayFromWhiteSide(boardViewModel);
		
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReader, consoleWriterFactory, boardViewModel);
		foreach(var command in consoleCommandInputProducer)
		{
			command.Execute(session).Display();
			DisplayFromWhiteSide(boardViewModel);
			foreach (var item in session.MoveHistory)
			{
				new ValidMoveView(new MoveViewModel(item), boardViewModel, consoleWriterFactory).Display();
			}
		}
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
