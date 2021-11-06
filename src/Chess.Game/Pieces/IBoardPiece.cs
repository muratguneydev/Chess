namespace Chess.Game;

public interface IBoardPiece
{
	Color Color { get; }
	bool IsEmpty { get; }
	Type PieceType { get; }

	Move Move(Cell cellDestination);
	bool HasSameColor(IBoardPiece otherBoardPiece);
}