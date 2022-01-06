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
		Move move;
		try
		{
			move = new ConsoleMoveInput(moveString, this.boardViewModel).Move;
		}
		catch (Exception ex)
		{
			return new ErrorView(new ErrorViewModel(ex.Message), this.consoleWriterFactory);
		}

		var executedMove = move;//.Go();
		if (!executedMove.IsValid)
			return new InvalidMoveView(new MoveViewModel(executedMove), this.boardViewModel, this.consoleWriterFactory);
		
		session.Move(executedMove);
		return new ValidMoveView(new MoveViewModel(executedMove), this.boardViewModel, this.consoleWriterFactory);
	}
}