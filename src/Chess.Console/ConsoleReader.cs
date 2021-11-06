namespace Chess.Console;

public class ConsoleReader : IConsoleReader
{
	public string ReadLine()
	{
		var input = System.Console.ReadLine();
		return string.IsNullOrWhiteSpace(input) ? string.Empty : input;
	}
}