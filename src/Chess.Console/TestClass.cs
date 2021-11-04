using Chess.Game;

namespace Chess.Console;

public static class TestClass
{
	public static void BlackPawnShouldBeAbleToAttack(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCellBlackPiece(getFromToWithBoard, new BlackPawn());
		var cellToBeAttacked = fromTo.FromTo.To;;
		cellToBeAttacked.Initialize(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board, cellToBeAttacked));
		
		var move = fromTo.FromTo.Move();
	}

	public static void KingShouldBeAbleToMoveIfEmpty(Func<Board, FromTo> getFromToWithBoard, Func<Board, Cell> getBlockingCell)
	{
		var fromTo = BoardTestHelper.GetInitializedBoardWithFromCell(getFromToWithBoard, new King());
		var middleCellWithAnotherPiece = getBlockingCell(fromTo.Board);
		middleCellWithAnotherPiece.Initialize(new WhitePieceDecorator(new Knight(), fromTo.Session, fromTo.Board, middleCellWithAnotherPiece));
		
		var move = fromTo.FromTo.Move();
	}

	public static void QueenShouldBeAbleToMoveIfEmpty(Func<Board,FromTo> getFromToWithBoard)
	{
		var fromToForTest = BoardTestHelper.InitializeBoardWithFromCell(getFromToWithBoard, new Queen());
		var move = fromToForTest.Move();
		//CellTestHelper.AssertIsValidMove(fromToForTest);
	}

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

	public static class SessionTestHelper
	{
		public static Session Create(WhitePlayer? playerWhite = default(WhitePlayer), BlackPlayer? playerBlack = default(BlackPlayer))
		{
			playerWhite = playerWhite ?? new WhitePlayer();
			playerBlack = playerBlack ?? new BlackPlayer();

			return new Session(playerWhite, playerBlack);
		}
	}

	public static class BoardTestHelper
	{
	public static Board Create(Session? session = null)
	{
		session = session ?? SessionTestHelper.Create();
		return new Board(session);
	}

	public static FromTo InitializeBoardWithFromCell(Func<Board, FromTo> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		var fromTo = fromToGetter(board);
		
		fromTo.From.Initialize(new WhitePieceDecorator(piece, session, board, fromTo.From));
		return fromTo;
	}

	public static FromToWithBoardAndSession GetInitializedBoardWithFromCell(Func<Board, FromTo> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		var fromTo = fromToGetter(board);
		
		fromTo.From.Initialize(new WhitePieceDecorator(piece, session, board, fromTo.From));
		return new FromToWithBoardAndSession(fromTo, board, session);
	}

	public static FromToWithBoardAndSession GetInitializedBoardWithFromCellWhitePiece(Func<Board, FromTo> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		var fromTo = fromToGetter(board);
		
		fromTo.From.Initialize(new WhitePieceDecorator(piece, session, board, fromTo.From));
		return new FromToWithBoardAndSession(fromTo, board, session);
	}

	public static FromToWithBoardAndSession GetInitializedBoardWithFromCellBlackPiece(Func<Board, FromTo> fromToGetter, Piece piece)
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		var fromTo = fromToGetter(board);
		
		fromTo.From.Initialize(new BlackPieceDecorator(piece, session, board, fromTo.From));
		return new FromToWithBoardAndSession(fromTo, board, session);
	}
}

}