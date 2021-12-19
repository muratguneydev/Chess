namespace Chess.Game;

public class CellHistory
{
	private readonly LinkedList<Cell> history = new LinkedList<Cell>();

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
			return EmptyCell.Cell;

		if (this.GetEmptyIfNotFound(this.history.Last).IsEmpty)
			return EmptyCell.Cell;
		return this.GetEmptyIfNotFound(this.history.Last.Previous);
	}

	private Cell GetLast()
	{
		if (this.history.Last == null)
			return EmptyCell.Cell;
		
		return this.history.Last.Value;
	}

	private Cell GetEmptyIfNotFound(LinkedListNode<Cell>? historyNode)
	{
		return historyNode == null ? EmptyCell.Cell : historyNode.Value;
		
	}
}