using Chess.Api.Request;
using Chess.Game;

namespace Chess.Api;

public class BoardDTOFactory
{
	private readonly PieceDTOFactory pieceDTOFactory;

	public BoardDTOFactory(PieceDTOFactory pieceDTOFactory)
	{
		this.pieceDTOFactory = pieceDTOFactory;
	}

	public BoardDTO Get(Board board)
	{
		return new BoardDTO(this.GetCellsFromBoard(board));
	}

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