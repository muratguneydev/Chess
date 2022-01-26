using Chess.Game;

namespace Chess.Api.DTO;

public record BoardDTO
{
	private readonly PieceDTOFactory pieceDTOFactory;

	public BoardDTO(Board board, PieceDTOFactory pieceDTOFactory)
	{
		this.pieceDTOFactory = pieceDTOFactory;
		this.Cells = this.GetCellsFromBoard(board).ToArray();
	}

	public IEnumerable<CellDTO> Cells { get; }

	private IEnumerable<CellDTO> GetCellsFromBoard(Board board)
	{
		for (var x = 0; x < board.XSize; x++)
		{
			for (var y = 0; y < board.YSize; y++)
			{
				var boardPiece = board.GetCell(x, y).Piece;
				yield return new CellDTO(x, y, this.CreatePieceDTO(boardPiece));
			}
		}
	}

	private PieceDTO CreatePieceDTO(IBoardPiece piece)
	{
		var dto = this.pieceDTOFactory.Get(piece);
		
		switch (piece.Color)
		{
			case Color.None:
				return dto;
			case Color.White:
				return new WhitePieceDecoratorDTO(dto);
			case Color.Black:
				return new BlackPieceDecoratorDTO(dto);
		}

		return dto;
	}
}
