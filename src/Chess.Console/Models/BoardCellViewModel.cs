using Chess.Game;

namespace Chess.Console;

public class BoardCellViewModel
{
	public BoardCellViewModel(Cell cell)
	{
		this.Cell = cell;
	}

	public Coordinate Coordinate => this.Cell.Coordinate;

	public BoardPieceViewModel BoardPieceViewModel => new BoardPieceViewModel(this.Cell.Piece);

	public Cell Cell { get; }
}