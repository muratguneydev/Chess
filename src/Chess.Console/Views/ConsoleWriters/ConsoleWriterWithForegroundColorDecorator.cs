namespace Chess.Console;

public class ConsoleWriterWithForegroundColorDecorator : IConsoleWriter
{
	private readonly IConsoleWriter consoleWriter;
	private readonly ConsoleColor consoleColor;

	public ConsoleWriterWithForegroundColorDecorator(IConsoleWriter consoleWriter, ConsoleColor consoleColor)
	{
		this.consoleWriter = consoleWriter;
		this.consoleColor = consoleColor;
	}
	
	public void Write(string displayString)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.Write(displayString);
	}

	public void WriteLine(string displayString)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteLine(displayString);
	}

	public void WriteLine()
	{
		//this.ChangeForegroundColor();
		this.consoleWriter.WriteLine();
	}

	public void WriteLineWithSeparatorPostfix(string displayString)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteLineWithSeparatorPostfix(displayString);
	}

	public void WriteLineWithSeparatorPrefix(string displayString)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteLineWithSeparatorPrefix(displayString);
	}

	public void WriteLineWithSeparatorPrefix(IEnumerable<string> displayItems)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteLineWithSeparatorPrefix(displayItems);
	}

	public void WriteSeparator()
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteSeparator();
	}

	public void WriteWithSeparatorPostfix(string displayString)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteWithSeparatorPostfix(displayString);
	}

	public void WriteWithSeparatorPrefix(string displayString)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteWithSeparatorPrefix(displayString);
	}

	public void WriteWithSeparatorPrefix(IEnumerable<string> displayItems)
	{
		this.ChangeForegroundColor();
		this.consoleWriter.WriteWithSeparatorPrefix(displayItems);
	}

	private void ChangeForegroundColor()
	{
		System.Console.ForegroundColor = this.consoleColor;
	}
}