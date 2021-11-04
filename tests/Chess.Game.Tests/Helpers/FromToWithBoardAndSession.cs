namespace Chess.Game.Tests;

public class FromToWithBoardAndSession
{
	public FromToWithBoardAndSession(FromTo fromTo, Board board, Session session)
	{
		this.FromTo = fromTo;
		this.Board = board;
		this.Session = session;
	}

	public FromTo FromTo { get; }
	public Board Board { get; }
	public Session Session { get; }
}