namespace Chess.Game;

public interface IBoardPiece
{
	Color Color { get; }
	bool IsEmpty { get; }
	bool IsFirstMove { get; }
	Coordinate PreviousCoordinate { get; }
	bool IsBlack { get; }
	bool IsWhite { get; }
	bool CanMove(Move move);
	MovePath GetMovePath(Move move);
	bool HasSameColor(IBoardPiece otherBoardPiece);
	bool IsOfType(Type type);
	Cell PopLastCellFromHistory();
	void RecordCurrentCellInHistory(Cell cell);
}
