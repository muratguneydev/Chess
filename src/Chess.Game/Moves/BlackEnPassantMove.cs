namespace Chess.Game;

public record BlackEnPassantMove : EnPassantMove
{
	public BlackEnPassantMove(Cell from, Cell to)
		: base(from, to)
	{
	}

	protected override Cell AttackedCell => this.From.GetCellOnSameBoard(this.To.X, this.To.Y + 1);
}