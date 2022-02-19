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

	public Board Convert()
	{
		return new Board(this.GetCells());
	}

	private Cell[,] GetCells()
	{
		var dummyBoard = new Board();
		var cells = new Cell[8, 8];
		foreach (var cell in this.Cells)
		{
			cells[cell.X, cell.Y] = cell.Convert(dummyBoard);
		}

		return cells;
	}
}
