namespace Chess.Console;

public class ConsoleWriter : IConsoleWriter
{
	private readonly string separator;

	public ConsoleWriter(string separator)
	{
		this.separator = separator;
	}

	public void Write(string displayString)
	{
		System.Console.Write(displayString);
	}

	public void WriteSeparator()
	{
		System.Console.Write(this.separator);
	}

	public void WriteLine(string displayString)
	{
		System.Console.WriteLine(displayString);
	}

	public void WriteLine()
	{
		System.Console.WriteLine(string.Empty);
	}

	public void WriteWithSeparatorPostfix(string displayString)
	{
		this.Write($"{displayString}{this.separator}");
	}

	public void WriteLineWithSeparatorPostfix(string displayString)
	{
		this.WriteWithSeparatorPostfix(displayString);
		this.WriteLine();
	}

	public void WriteWithSeparatorPrefix(string displayString)
	{
		this.Write($"{this.separator}{displayString}");
	}

	public void WriteLineWithSeparatorPrefix(string displayString)
	{
		this.WriteWithSeparatorPrefix(displayString);
		this.WriteLine();
	}

	public void WriteWithSeparatorPrefix(IEnumerable<string> displayItems)
	{
		foreach(var displayItem in displayItems)
		{
			this.WriteWithSeparatorPrefix(displayItem);
		}
	}

	public void WriteLineWithSeparatorPrefix(IEnumerable<string> displayItems)
	{
		this.WriteWithSeparatorPrefix(displayItems);
		this.WriteLine();
	}
}
