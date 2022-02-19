using System.Collections;

namespace Chess.Game;

public class MoveHistory : IEnumerable<Move>
{
	private readonly Stack<Move> moves = new Stack<Move>();
	private readonly Board board;

	public MoveHistory(Board board)
	{
		this.board = board;
	}

	public MoveHistory(Board board, IEnumerable<Move> moveCollection)
		: this(board)
	{
		moveCollection.ToList().ForEach(move => this.Push(move));
	}

	public void Push(Move move)
	{
		this.moves.Push(move);
	}

	public Move Pop()
	{
		if (!this.moves.Any())
			return this.board.EmptyMove;
			
		return this.moves.Pop();
	}

	public IEnumerator<Move> GetEnumerator()
	{
		return this.moves.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.moves.GetEnumerator();
	}

	public Move LastMove => this.moves.Any() ? this.moves.Peek() : this.board.EmptyMove;
}
