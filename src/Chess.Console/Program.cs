using Chess.Game;

namespace Chess.Console;

class Program
{
	private static readonly ConsoleWriterFactory consoleWriterFactory = new ConsoleWriterFactory();
	static void Main(string[] args)
	{
		//TestClass.BlackPawnShouldBeAbleToAttack(board => new FromTo(board.b7, board.a6));		

		var whitePlayer = new WhitePlayer();
		var blackPlayer = new BlackPlayer();
		var session = new Session(whitePlayer, blackPlayer);
		
		var board = new Board(session);
		board.SetOpeningPosition();
		
		var consoleCommandInputIterator = new ConsoleCommandInputIterator(consoleWriterFactory, new BoardViewModel(board));
		while (consoleCommandInputIterator.MoveNext())
		{
			var boardViewModel = new BoardViewModel(board);
			consoleCommandInputIterator.UpdateBoardInformation(boardViewModel);
			DisplayFromWhiteSide(boardViewModel);

			var command = consoleCommandInputIterator.Current;
			command.Execute(session).Display();
			
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
