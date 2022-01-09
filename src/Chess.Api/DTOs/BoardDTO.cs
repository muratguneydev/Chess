using Chess.Game;

namespace Chess.Api.DTO;

public class BoardDTO
{
	private readonly Dictionary<Type, Func<PieceDTO>> pieceFactory = new Dictionary<Type, Func<PieceDTO>>
	{
		{ typeof(EmptyPiece), () => new EmptyPieceDTO() },
		{ typeof(Pawn), () => new PawnDTO() },
		{ typeof(Rook), () => new RookDTO() },
		{ typeof(Knight), () => new KnightDTO() },
		{ typeof(Bishop), () => new BishopDTO() },
		{ typeof(Queen), () => new QueenDTO() },
		{ typeof(King), () => new KingDTO() }
	};

	public BoardDTO(Board board)
	{
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
		var dto = pieceFactory
			.Single(pieceTypeFactory => piece.IsOfType(pieceTypeFactory.Key))
			.Value();
		
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