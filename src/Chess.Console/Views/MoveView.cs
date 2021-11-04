namespace Chess.Console;

public abstract class MoveView : View
{
	private readonly MoveViewModel moveViewModel;
	private readonly BoardViewModel boardViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private readonly ConsoleColor backgroundColour;
	private readonly ConsoleColor foregroundColor;

	public MoveView(MoveViewModel moveViewModel, BoardViewModel boardViewModel,
		ConsoleWriterFactory consoleWriterFactory, ConsoleColor backgroundColour, ConsoleColor foregroundColor)
	{
		this.moveViewModel = moveViewModel;
		this.boardViewModel = boardViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
		this.backgroundColour = backgroundColour;
		this.foregroundColor = foregroundColor;
	}

	public override void Display()
	{
		this.consoleWriterFactory
			.Get(this.backgroundColour, this.foregroundColor)
			.WriteLine($"{boardViewModel.GetCellName(this.moveViewModel.From.Cell)}-{boardViewModel.GetCellName(this.moveViewModel.To.Cell)}");
	}
}

public class ValidMoveView : MoveView
{
	public ValidMoveView(MoveViewModel moveViewModel, BoardViewModel boardViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(moveViewModel, boardViewModel, consoleWriterFactory, ConsoleColor.Black, ConsoleColor.DarkMagenta)
	{
	}
}

public class InvalidMoveView : MoveView
{
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public InvalidMoveView(MoveViewModel moveViewModel, BoardViewModel boardViewModel, ConsoleWriterFactory consoleWriterFactory)
		: base(moveViewModel, boardViewModel, consoleWriterFactory, ConsoleColor.Black, ConsoleColor.Red)
	{
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override void Display()
	{
		this.consoleWriterFactory
			.Get(ConsoleColor.Black, ConsoleColor.Red)
			.Write("Invalid move...");
		 base.Display();
	}
}