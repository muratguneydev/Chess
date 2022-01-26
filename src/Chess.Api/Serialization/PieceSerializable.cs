using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record PieceSerializable
{
	[JsonConstructor]
	public PieceSerializable(string pieceType, Color color, IEnumerable<Coordinate> cellHistory)
	{
		this.PieceType = pieceType;
		this.Color = color;
		this.CellHistory = cellHistory;
	}

	public string PieceType { get; }
	public Color Color { get; }
	public IEnumerable<Coordinate> CellHistory { get; }

	public IBoardPiece Convert()
	{
		if (this.Color == Color.None)
			return EmptyBoardPiece.BoardPiece;

		var type = typeof(Piece).Assembly.GetType(this.PieceType);
		if (type == null)
			throw new Exception($"Cannot deserialize piece from type:{this.PieceType};");
		var originalPiece = Activator.CreateInstance(type) as Piece;
		if (originalPiece == null)
			throw new Exception($"Cannot deserialize piece from type:{this.PieceType};");

		var cellHistory = new CellHistory(new LinkedList<Coordinate>(this.CellHistory));

		switch (this.Color)
		{
			case Color.Black:
				return new BlackPieceDecorator(originalPiece, cellHistory);
			case Color.White:
				return new WhitePieceDecorator(originalPiece, cellHistory);
		}

		return EmptyBoardPiece.BoardPiece;
	}
}
