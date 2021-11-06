using Chess.Game;

namespace Chess.Console;

public class MoveCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly BoardViewModel boardViewModel;
	private readonly string moveString;

	public MoveCommand(ConsoleWriterFactory consoleWriterFactory, BoardViewModel boardViewModel,
		string moveString)
	{
		this.consoleWriterFactory = consoleWriterFactory;
		this.boardViewModel = boardViewModel;
		this.moveString = moveString;
	}
	public override View Execute(Session session)
	{
		FromTo fromTo;
		try
		{
			fromTo = new ConsoleMoveInput(moveString, this.boardViewModel).FromTo;
		}
		catch (Exception ex)
		{
			return new ErrorView(new ErrorViewModel(ex.Message), this.consoleWriterFactory);
		}

		var move = fromTo.Move();
		if (!move.IsValid)
			return new InvalidMoveView(new MoveViewModel(move), this.boardViewModel, this.consoleWriterFactory);
		
		session.Next(move);
		return new ValidMoveView(new MoveViewModel(move), this.boardViewModel, this.consoleWriterFactory);
	}
}