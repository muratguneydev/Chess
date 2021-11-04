namespace Chess.Console;

public class ConsoleWriterFactory
{
	private readonly TabSeparatedConsoleWriter consoleWriter;

	public ConsoleWriterFactory()
	{
		this.consoleWriter = new TabSeparatedConsoleWriter();
	}

	public virtual IConsoleWriter Get()
	{
		return this.consoleWriter;
	}

	public virtual IConsoleWriter Get(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
	{
		return new ConsoleWriterWithBackgroundColorDecorator(
			new ConsoleWriterWithForegroundColorDecorator(this.consoleWriter, foregroundColor),
			backgroundColor);
	}
}