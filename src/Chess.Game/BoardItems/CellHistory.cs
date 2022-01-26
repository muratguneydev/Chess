using System.Collections;

namespace Chess.Game;

public class CellHistory : IEnumerable<Coordinate>
{
	private readonly LinkedList<Coordinate> history;// = new LinkedList<Coordinate>();

	public CellHistory()
	{
		this.history = new LinkedList<Coordinate>();
	}

	public CellHistory(LinkedList<Coordinate> history)
	{
		this.history = history;
	}

	public bool IsEmpty => !this.history.Any();
	public bool IsFirstMove => this.history.Count == 2;

	public void Push(Coordinate cell)
	{
		this.history.AddLast(cell);
	}

	public void Pop()
	{
		if (this.IsEmpty)
			return;

		this.history.RemoveLast();
	}

	public Coordinate GetPrevious()
	{
		//to avoid null warning
		if (this.history.Last == null)
			return EmptyCoordinate.Coordinate;

		if (this.GetEmptyIfNotFound(this.history.Last).IsEmpty)
			return EmptyCoordinate.Coordinate;
		return this.GetEmptyIfNotFound(this.history.Last.Previous);
	}

	private Coordinate GetEmptyIfNotFound(LinkedListNode<Coordinate>? historyNode)
	{
		return historyNode == null ? EmptyCoordinate.Coordinate : historyNode.Value;
		
	}

	public IEnumerator<Coordinate> GetEnumerator()
	{
		foreach (var coordinate in this.history)
		{
			yield return coordinate;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}