using Chess.Game;

namespace Chess.Api.DTO;

public abstract record PieceDTO
{
	public abstract string Name { get; }
	public virtual Color Color => Color.None;
}
