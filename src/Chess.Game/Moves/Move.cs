namespace Chess.Game;

public class Move
{
	public Move(Cell cellFrom, Cell cellTo)
	{
		this.From = cellFrom;
		this.To = cellTo;
	}

	public Cell From { get; }
	public Cell To { get; }
	public bool IsValid => !(this is InvalidMove);
	public Color Color => this.From.IsOccupied ? this.From.Piece.Color : this.To.Piece.Color;
}
