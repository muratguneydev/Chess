using Chess.Game;

namespace Chess.Api.Controllers;

public record EmptyPieceSerializable : PieceSerializable
{
	private static EmptyPieceSerializable emptyPieceSerializable = new EmptyPieceSerializable();

	private EmptyPieceSerializable()
		: base(typeof(EmptyPiece).Name, Color.None, new LinkedList<Coordinate>())
	{
	}

	public static EmptyPieceSerializable PieceSerializable => emptyPieceSerializable;
}