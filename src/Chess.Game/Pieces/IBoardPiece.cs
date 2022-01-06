namespace Chess.Game;

public interface IBoardPiece
{
	Color Color { get; }
	bool IsEmpty { get; }
	Type PieceType { get; }
	bool IsFirstMove { get; }
	Cell PreviousCell { get; }
	Board Board { get; }

	bool CanMove(Move move);
	MovePath GetMovePath(Move move);
	bool HasSameColor(IBoardPiece otherBoardPiece);
	Cell PopLastCellFromHistory();
	void RecordCurrentCellInHistory(Cell cell);
}
