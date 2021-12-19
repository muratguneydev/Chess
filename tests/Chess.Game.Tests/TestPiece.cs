using Chess.Game.Tests.Helpers;

namespace Chess.Game.Tests;

internal class TestPiece : BoardPieceDecorator
{
	private readonly Color color;

	public TestPiece()
		: base(new Rook(), SessionTestHelper.Create(), BoardTestHelper.Create(), new CellHistory())
	{
		this.color = Color.White;
	}

	public TestPiece(Color color)
		: base(new Rook(), SessionTestHelper.Create(), BoardTestHelper.Create(), new CellHistory())
	{
		this.color = color;
	}

	public TestPiece(Piece piece, Color color)
		: base(piece, SessionTestHelper.Create(), BoardTestHelper.Create(), new CellHistory())
	{
		this.color = color;
	}

	public TestPiece(Piece piece, Color color, Session session, Board board)
		: base(piece, session, board, new CellHistory())
	{
		this.color = color;
	}

	public override Color Color => this.color;
}
