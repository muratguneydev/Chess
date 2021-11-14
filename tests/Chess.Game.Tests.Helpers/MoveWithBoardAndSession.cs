namespace Chess.Game.Tests.Helpers;

public class MoveWithBoardAndSession
{
	public MoveWithBoardAndSession(Move fromTo, Board board, Session session)
	{
		this.Move = fromTo;
		this.Board = board;
		this.Session = session;
	}

	public Move Move { get; }
	public Board Board { get; }
	public Session Session { get; }
}