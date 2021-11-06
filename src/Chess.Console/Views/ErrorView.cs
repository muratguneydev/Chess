namespace Chess.Console;

public class ErrorView : View
{
	private readonly ErrorViewModel errorViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public ErrorView(ErrorViewModel errorViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.errorViewModel = errorViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override void Display()
	{
		this.consoleWriterFactory
			.Get(ConsoleColor.Black, ConsoleColor.Red)
			.WriteLine(this.errorViewModel.ErrorDescription);
	}
}
