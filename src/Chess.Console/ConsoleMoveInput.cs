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
		this.Move = fromCell.GetMove(toCell);
	}

	public Move Move { get; }
}