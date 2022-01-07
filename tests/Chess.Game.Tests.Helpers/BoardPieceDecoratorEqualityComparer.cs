using System.Diagnostics.CodeAnalysis;

namespace Chess.Game.Tests.Helpers;

public class BoardPieceDecoratorEqualityComparer : IEqualityComparer<IBoardPiece>
{
	public bool Equals(IBoardPiece? x, IBoardPiece? y)
	{
		if (x == null || y == null)
			return false;

		return x.Color == y.Color
			&& x.PieceType == y.PieceType;
	}

	public int GetHashCode([DisallowNull] IBoardPiece boardPiece)
	{
		return (int)boardPiece.Color * 17 + boardPiece.PieceType.ToString().GetHashCode();
	}
}