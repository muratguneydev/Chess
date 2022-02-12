namespace Chess.Api.Request;

public abstract record PieceDTO
{
	public abstract string Name { get; }
	public virtual SideColor Color => SideColor.None;
}
