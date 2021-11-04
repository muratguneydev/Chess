namespace Chess.Console;

public class ConsoleWriterWithBackgroundColorDecorator : IConsoleWriter
{
	private readonly IConsoleWriter consoleWriter;
	private readonly ConsoleColor consoleColor;

	public ConsoleWriterWithBackgroundColorDecorator(IConsoleWriter consoleWriter, ConsoleColor consoleColor)
	{
		this.consoleWriter = consoleWriter;
		this.consoleColor = consoleColor;
	}
	
	public void Write(string displayString)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.Write(displayString);
	}

	public void WriteLine(string displayString)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteLine(displayString);
	}

	public void WriteLine()
	{
		//this.ChangeForegroundColor();
		this.consoleWriter.WriteLine();
	}

	public void WriteLineWithSeparatorPostfix(string displayString)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteLineWithSeparatorPostfix(displayString);
	}

	public void WriteLineWithSeparatorPrefix(string displayString)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteLineWithSeparatorPrefix(displayString);
	}

	public void WriteLineWithSeparatorPrefix(IEnumerable<string> displayItems)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteLineWithSeparatorPrefix(displayItems);
	}

	public void WriteSeparator()
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteSeparator();
	}

	public void WriteWithSeparatorPostfix(string displayString)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteWithSeparatorPostfix(displayString);
	}

	public void WriteWithSeparatorPrefix(string displayString)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteWithSeparatorPrefix(displayString);
	}

	public void WriteWithSeparatorPrefix(IEnumerable<string> displayItems)
	{
		this.ChangeBackgroundColor();
		this.consoleWriter.WriteWithSeparatorPrefix(displayItems);
	}

	private void ChangeBackgroundColor()
	{
		System.Console.BackgroundColor = this.consoleColor;
	}
}

