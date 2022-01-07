namespace Chess.Game;

public record WhiteEnPassantMove : EnPassantMove
{
	public WhiteEnPassantMove(Cell from, Cell to)
		: base(from, to)
	{
	}

	protected override Cell AttackedCell => this.From.GetCellOnSameBoard(this.To.X, this.To.Y - 1);
}
