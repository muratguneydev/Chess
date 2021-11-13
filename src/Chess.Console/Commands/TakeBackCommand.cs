using Chess.Game;

namespace Chess.Console;

public class TakeBackCommand : ChessCommand
{
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly BoardViewModel boardViewModel;

	public TakeBackCommand(ConsoleWriterFactory consoleWriterFactory, BoardViewModel boardViewModel)
	{
		this.consoleWriterFactory = consoleWriterFactory;
		this.boardViewModel = boardViewModel;
	}
	
	public override View Execute(Session session)
	{
		var lastMove = session.Back();
		var moveView = new ValidMoveView(new MoveViewModel(lastMove), this.boardViewModel, this.consoleWriterFactory);
		return new InformationViewDecorator(moveView, new InformationViewModel("Taking back:"), this.consoleWriterFactory);
	}
}
