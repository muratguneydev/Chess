using Chess.Game;

namespace Chess.Api.DTO;

public record MoveDTO
{
	private readonly Move move;
	private readonly PieceDTOFactory pieceDTOFactory;

	public MoveDTO(Move move, PieceDTOFactory pieceDTOFactory)
	{
		//this.From = new CellDTO(move.From.X, move.From.Y, pieceDTOFactory.Get(move.From.Piece));
		//this.To = new CellDTO(move.To.X, move.To.Y, pieceDTOFactory.Get(move.To.Piece));
		this.move = move;
		this.pieceDTOFactory = pieceDTOFactory;
	}

	public CellDTO From => new CellDTO(this.move.From.X, this.move.From.Y, this.pieceDTOFactory.Get(this.move.From.Piece));
	public CellDTO To => new CellDTO(this.move.To.X, this.move.To.Y, this.pieceDTOFactory.Get(this.move.To.Piece));
}