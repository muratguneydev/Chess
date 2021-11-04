namespace Chess.Game;

public record FromTo
{
	public FromTo(Cell from, Cell to)
	{
		this.From = from;
		this.To = to;
	}

	public Cell From { get; }
	public Cell To { get; }

	public bool IsOnSameRow => this.From.Y == this.To.Y;
	public bool IsOnSameColumn => this.From.X == this.To.X;
	public int LowestColumn => Math.Min(this.From.X, this.To.X);
	public int HighestColumn => Math.Max(this.From.X, this.To.X);
	public int LowestRow => Math.Min(this.From.Y, this.To.Y);
	public int HighestRow => Math.Max(this.From.Y, this.To.Y);
	public bool HasSameColor => this.From.Piece.HasSameColor(this.To.Piece);

	public Move Move()
	{
		return this.From.Move(this.To);
	}
}