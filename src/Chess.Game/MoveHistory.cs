using System.Collections;

namespace Chess.Game;

public class MoveHistory : IEnumerable<Move>
{
	private readonly Stack<Move> moves = new Stack<Move>();

	public void Push(Move move)
	{
		this.moves.Push(move);
	}

	public Move Pop()
	{
		if (!this.moves.Any())
			return EmptyMove.Move;
			
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

	public Move LastMove => this.moves.Any() ? this.moves.Peek() : EmptyMove.Move;
}
