namespace Chess.Game;

public class CellHistory
{
	private readonly LinkedList<Cell> history = new LinkedList<Cell>();
	private readonly Board board;

	public CellHistory(Board board)
	{
		this.board = board;
	}

	public bool IsEmpty => !this.history.Any();
	public bool IsFirstMove => this.history.Count == 2;

	public void Push(Cell cell)
	{
		this.history.AddLast(cell);
	}

	public Cell Pop()
	{
		var last = this.GetLast();
		if (last.IsEmpty)
			return last;

		this.history.RemoveLast();
		return last;
	}

	public Cell GetPrevious()
	{
		//to avoid null warning
		if (this.history.Last == null)
			return this.board.EmptyCell;

		if (this.GetEmptyIfNotFound(this.history.Last).IsEmpty)
			return this.board.EmptyCell;
		return this.GetEmptyIfNotFound(this.history.Last.Previous);
	}

	private Cell GetLast()
	{
		if (this.history.Last == null)
			return this.board.EmptyCell;
		
		return this.history.Last.Value;
	}

	private Cell GetEmptyIfNotFound(LinkedListNode<Cell>? historyNode)
	{
		return historyNode == null ? this.board.EmptyCell : historyNode.Value;
		
	}
}