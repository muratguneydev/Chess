namespace Chess.Game;

public record EnPassantMove : Move
{
	public EnPassantMove(Cell from, Cell to)
		: base(from, to)
	{
	}

	public override Move Go()
	{
		this.To.SetPiece(this.From.Piece);
		this.From.MakeEmpty();
		GetAttackedCell().MakeEmpty();

		return this;
	}

	private Cell GetAttackedCell()
	{
		return this.From.Board.GetCell(this.To.X, this.To.Y + 1);
	}
}