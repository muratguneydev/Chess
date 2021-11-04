using Chess.Game;

namespace Chess.Console;

public class BoardCellView : View
{
	private readonly BoardCellViewModel boardCellViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public BoardCellView(BoardCellViewModel boardCellViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.boardCellViewModel = boardCellViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override void Display()
	{
		var boardPieceViewModel = this.boardCellViewModel.BoardPieceViewModel;
		modelViewMapping[boardPieceViewModel.PieceType](boardPieceViewModel, this.consoleWriterFactory).Display();
	}

	private readonly Dictionary<Type, Func<BoardPieceViewModel, ConsoleWriterFactory, View>> modelViewMapping
		= new Dictionary<Type, Func<BoardPieceViewModel, ConsoleWriterFactory, View>>
	{
		{ typeof(Rook), (boardPieceViewModel, consoleWriterFactory) => new BoardPieceView(boardPieceViewModel, consoleWriterFactory) },
		{ typeof(Knight), (boardPieceViewModel, consoleWriterFactory) => new BoardPieceView(boardPieceViewModel, consoleWriterFactory) },
		{ typeof(Bishop), (boardPieceViewModel, consoleWriterFactory) => new BoardPieceView(boardPieceViewModel, consoleWriterFactory) },
		{ typeof(King), (boardPieceViewModel, consoleWriterFactory) => new BoardPieceView(boardPieceViewModel, consoleWriterFactory) },
		{ typeof(Queen), (boardPieceViewModel, consoleWriterFactory) => new BoardPieceView(boardPieceViewModel, consoleWriterFactory) },
		{ typeof(BlackPawn), (boardPieceViewModel, consoleWriterFactory) => new BoardPieceView(boardPieceViewModel, consoleWriterFactory) },
		{ typeof(WhitePawn), (boardPieceViewModel, consoleWriterFactory) => new BoardPieceView(boardPieceViewModel, consoleWriterFactory) },
		{ typeof(EmptyPiece), (boardPieceViewModel, consoleWriterFactory) => new EmptyBoardPieceView(boardPieceViewModel, consoleWriterFactory) }
	};
}
