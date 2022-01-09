using Chess.Game;

namespace Chess.Api.DTO;

public abstract class PieceDTO
{
	public abstract string Name { get; }
	public virtual Color Color => Color.None;
}
