using Chess.Game;

namespace Chess.Console;

public class MoveViewModel
{
	private readonly Move move;

	public MoveViewModel(Move move)
	{
		this.move = move;
	}

	public Color Color => this.move.Color;
	public BoardCellViewModel From => new BoardCellViewModel(this.move.From);
	public BoardCellViewModel To => new BoardCellViewModel(this.move.To);
	public bool IsValid => this.move.IsValid;
}