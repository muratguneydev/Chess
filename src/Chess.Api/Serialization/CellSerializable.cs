using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record CellSerializable
{
	[JsonConstructor]
	public CellSerializable(int x, int y, PieceSerializable piece)
	{
		this.X = x;
		this.Y = y;
		this.Piece = piece;
	}

	public int X { get; }
	public int Y { get; }
	public PieceSerializable Piece { get; }
}
