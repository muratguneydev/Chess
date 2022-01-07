using Chess.Game.Tests.Helpers;

namespace Chess.Game.Tests;

internal class TestPiece : BoardPieceDecorator
{
	private readonly Color color;
	private static Board defaultBoard = BoardTestHelper.Create();

	public TestPiece()
		: base(new Rook(), defaultBoard, new CellHistory(defaultBoard))
	{
		this.color = Color.White;
	}

	public TestPiece(Color color)
		: base(new Rook(), defaultBoard, new CellHistory(defaultBoard))
	{
		this.color = color;
	}

	public TestPiece(Piece piece, Color color)
		: base(piece, defaultBoard, new CellHistory(defaultBoard))
	{
		this.color = color;
	}

	public TestPiece(Piece piece, Color color, Board board)
		: base(piece, board, new CellHistory(board))
	{
		this.color = color;
	}

	public override Color Color => this.color;
}
