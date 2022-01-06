namespace Chess.Game.Tests.Helpers;

public class MoveWithBoardAndSession
{
	public MoveWithBoardAndSession(Move move, Board board, Session session)
	{
		this.Move = move;
		this.Board = board;
		this.Session = session;
	}

	public Move Move { get; }
	public Board Board { get; }
	public Session Session { get; }
}