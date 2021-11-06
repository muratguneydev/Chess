namespace Chess.Console;

public interface IConsoleWriter
{
	void Write(string displayString);
	void WriteLine(string displayString);
	void WriteLine();
	void WriteLineWithSeparatorPostfix(string displayString);
	void WriteLineWithSeparatorPrefix(string displayString);
	void WriteLineWithSeparatorPrefix(IEnumerable<string> displayItems);
	void WriteSeparator();
	void WriteWithSeparatorPostfix(string displayString);
	void WriteWithSeparatorPrefix(string displayString);
	void WriteWithSeparatorPrefix(IEnumerable<string> displayItems);
}
