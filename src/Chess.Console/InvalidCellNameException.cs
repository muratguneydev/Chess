namespace Chess.Console;

public class InvalidCellNameException : ArgumentException
{
	public InvalidCellNameException(string cellName)
		: base($"'{cellName}' is not a valid cell name.")
	{
	}
}

