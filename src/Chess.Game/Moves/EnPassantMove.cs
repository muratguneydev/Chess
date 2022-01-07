namespace Chess.Game;

public abstract record EnPassantMove : Move
{
	public EnPassantMove(Cell from, Cell to)
		: base(from, to)
	{
	}

	public override Move Go()
	{
		this.To.SetPiece(this.From.Piece);
		this.From.MakeEmpty();
		this.AttackedCell.MakeEmpty();

		return this;
	}

	protected abstract Cell AttackedCell { get; }
}
