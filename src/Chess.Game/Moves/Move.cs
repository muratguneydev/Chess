namespace Chess.Game;

public record Move
{
	private readonly IBoardPiece FromPiece;
	private readonly IBoardPiece ToPiece;

	public Move(Cell from, Cell to)
	{
		this.From = from;
		this.To = to;
		this.FromPiece = this.From.Piece;
		this.ToPiece = this.To.Piece;
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
	public bool IsValid => !(this is InvalidMove);
	public Color Color => this.From.IsOccupied ? this.From.Piece.Color : this.To.Piece.Color;

	public Move Go()
	{
		var move = this.From.Move(this.To);
		// this.FromPiece.RecordCurrentCellInHistory(this.From);
		// this.ToPiece.RecordCurrentCellInHistory(this.To);
		return move;
	}

	public void GoBack()
	{
		this.From.GoBack(this.FromPiece);
		this.To.GoBack(this.ToPiece);

		// this.From.SetPiece(this.FromPiece);
		// this.FromPiece.PopLastCellFromHistory();
		// this.To.SetPiece(this.ToPiece);
		// this.ToPiece.PopLastCellFromHistory();
	}
}