using Chess.Game;

namespace Chess.Console;

public record ConsoleMoveInput
{
	public ConsoleMoveInput(string moveString, BoardViewModel boardViewModel)
	{
		if (moveString == null)
			throw new InvalidMoveStringException(string.Empty);
		var moveStringParts = moveString.Split("-");
		if (moveStringParts.Length != 2)
			throw new InvalidMoveStringException(moveString);
		
		var fromCellString = moveStringParts[0];
		var toCellString = moveStringParts[1];
		
		var fromCell = boardViewModel.GetCell(fromCellString);
		var toCell = boardViewModel.GetCell(toCellString);
		this.FromTo = new FromTo(fromCell, toCell);
	}

	public FromTo FromTo { get; }
}

public class InvalidCellNameException : ArgumentException
{
	public InvalidCellNameException(string cellName)
		: base($"'{cellName}' is not a valid cell name.")
	{
	}
}

public class InvalidMoveStringException : ArgumentException
{
	public InvalidMoveStringException(string moveString)
		: base($"Provided move string '{moveString}' wasn't in the correct format. The format is: cellFrom-cellTo example: a1-a2")
	{
	}
}

