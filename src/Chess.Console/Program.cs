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
		var boardViewModel = new BoardViewModel(board);
		
		while (true)
		{
			DisplayFromWhiteSide(boardViewModel);

			var moveString = System.Console.ReadLine();
			if (string.IsNullOrWhiteSpace(moveString))
				return;

			FromTo fromTo;
			try
			{
				fromTo = new ConsoleMoveInput(moveString, board).FromTo;
			}
			catch (Exception)
			{
				continue;
			}

			var move = fromTo.Move();
			if (!move.IsValid)
			{
				new InvalidMoveView(new MoveViewModel(move), boardViewModel, consoleWriterFactory).Display();
				continue;
			}

			session.Next(move);
			
			foreach (var item in session.MoveHistory)
			{
				new ValidMoveView(new MoveViewModel(item), boardViewModel, consoleWriterFactory).Display();
			}
			
		}

	}

	private FromTo GetFromTo(string moveString, Board board)
	{
		FromTo fromTo;
		try
		{
			fromTo = new ConsoleMoveInput(moveString, board).FromTo;
			return fromTo;
		}
		catch (InvalidMoveSringException invalidMoveString)
		{
			consoleWriterFactory
				.Get(ConsoleColor.White, ConsoleColor.Red)
				.WriteLine(invalidMoveString.Message);
			throw;
		}
		catch (InvalidCellNameException invalidCellName)
		{
			consoleWriterFactory
				.Get(ConsoleColor.White, ConsoleColor.Red)
				.WriteLine(invalidCellName.Message);
			throw;
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
