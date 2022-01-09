using Chess.Game;

namespace Chess.Console;

public class BoardPieceViewModel
{
	private Dictionary<Type, Func<ConsoleWriterFactory, BoardPieceView>> pieceViewMapping;

	private readonly IBoardPiece boardPiece;

	public BoardPieceViewModel(IBoardPiece boardPiece)
	{
		this.boardPiece = boardPiece;
		this.pieceViewMapping = this.GetPieceViewFactoryMapping();
	}

	public virtual Color Color => this.boardPiece.Color;

	public BoardPieceView GetBoardPieceView(ConsoleWriterFactory consoleWriterFactory)
	{
		return this.pieceViewMapping
			.Single(pieceTypeFactory => boardPiece.IsOfType(pieceTypeFactory.Key))
			.Value(consoleWriterFactory);
	}

	private Dictionary<Type, Func<ConsoleWriterFactory, BoardPieceView>> GetPieceViewFactoryMapping()
	{
		return new Dictionary<Type, Func<ConsoleWriterFactory, BoardPieceView>>
			{
				{ typeof(Rook), (consoleWriterFactory) => new RookView(this, consoleWriterFactory) },
				{ typeof(Knight), (consoleWriterFactory) => new KnightView(this, consoleWriterFactory) },
				{ typeof(Bishop), (consoleWriterFactory) => new BishopView(this, consoleWriterFactory) },
				{ typeof(King), (consoleWriterFactory) => new KingView(this, consoleWriterFactory) },
				{ typeof(Queen), (consoleWriterFactory) => new QueenView(this, consoleWriterFactory) },
				{ typeof(BlackPawn), (consoleWriterFactory) => new PawnView(this, consoleWriterFactory) },
				{ typeof(WhitePawn), (consoleWriterFactory) => new PawnView(this, consoleWriterFactory) },
				{ typeof(EmptyPiece), (consoleWriterFactory) => new EmptyPieceView(this, consoleWriterFactory) }
			};
	}
}
