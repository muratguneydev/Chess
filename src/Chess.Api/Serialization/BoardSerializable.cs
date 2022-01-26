using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record BoardSerializable
{
	[JsonConstructor]
	public BoardSerializable(IEnumerable<CellSerializable> cells)
	{
		this.Cells = cells;
	}

	public IEnumerable<CellSerializable> Cells { get; }

	public Cell[,] GetCells()
	{
		const int size = 8;
		var cells = new Cell[size, size];
		foreach (var cell in this.Cells)
		{
			cells[cell.X, cell.Y] = new Cell(cell.X, cell.Y, new Board(), cell.Piece.Convert());
		}

		return cells;
	}

	
}
