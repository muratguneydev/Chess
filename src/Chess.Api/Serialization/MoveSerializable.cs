using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record MoveSerializable
{
	[JsonConstructor]
	public MoveSerializable(CellSerializable from, CellSerializable to)
	{
		this.From = from;
		this.To = to;
	}

	public MoveSerializable(Move move)
	{
		this.From = GetCell(move.From);
		this.To = GetCell(move.To);
	}

	public CellSerializable From { get; }
	public CellSerializable To { get; }

	private static CellSerializable GetCell(Cell cell)
	{
		return new CellSerializable(cell.X, cell.Y, new PieceSerializable(cell.Piece.OriginalPieceType.FullName, cell.Piece.Color, cell.Piece.CellHistory));
	}
}