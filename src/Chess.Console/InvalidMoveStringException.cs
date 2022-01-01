namespace Chess.Console;

public class InvalidMoveStringException : ArgumentException
{
	public InvalidMoveStringException(string moveString)
		: base($"Provided move string '{moveString}' wasn't in the correct format. The format is: cellFrom-cellTo example: a1-a2")
	{
	}
}

