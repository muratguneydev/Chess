namespace Chess.Game;

public interface IBoardPiece
{
	Color Color { get; }
	bool IsEmpty { get; }
	Type PieceType { get; }

	bool CanMove(Cell from, Cell cellDestination);
	bool HasSameColor(IBoardPiece otherBoardPiece);
	Cell PopLastCellFromHistory();
	void RecordCurrentCellInHistory(Cell cell);
}
