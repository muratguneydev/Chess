using Chess.Game.Tests.Helpers;

namespace Chess.Game.Tests;

internal class TestPiece : BoardPieceDecorator
{
	public TestPiece(Cell initialCell)
		: base(new Rook(), SessionTestHelper.Create(), BoardTestHelper.Create(), initialCell)
	{
	}

	public override Color Color => Color.White;
}
