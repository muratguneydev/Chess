using Chess.Game;

namespace Chess.Console;

public class BoardPieceView : View
{
	private readonly BoardPieceViewModel boardPieceViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;
	private Dictionary<Color,IConsoleWriter> consoleWriterMap;

	public BoardPieceView(BoardPieceViewModel boardPieceViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.boardPieceViewModel = boardPieceViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
		this.consoleWriterMap = this.GetConsoleWriterMap();
	}

	public override void Display()
	{
		this.consoleWriterMap[this.boardPieceViewModel.Color]
			.Write(this.DisplayString);
	}
	
	protected virtual string DisplayString => pieceSymbol[this.boardPieceViewModel.PieceType];// this.boardPieceViewModel.PieceType.Name.First().ToString();

	private Dictionary<Color,IConsoleWriter> GetConsoleWriterMap()
	{
		var colorConsoleWriterMap =  new Dictionary<Color, IConsoleWriter>();
		colorConsoleWriterMap.Add(Color.Black, this.consoleWriterFactory.Get(ConsoleColor.Black,  ConsoleColor.Red));
		colorConsoleWriterMap.Add(Color.White, this.consoleWriterFactory.Get(ConsoleColor.Black,  ConsoleColor.White));
		colorConsoleWriterMap.Add(Color.None, this.consoleWriterFactory.Get(ConsoleColor.Black,  ConsoleColor.Gray));
		
		return colorConsoleWriterMap;
	}

	///We can create a view for each piece, like in EmptyBoardPieceView and override their DisplayString property.
	//Then do the mapping in BoardCellView.
	private static Dictionary<Type, string> pieceSymbol = new Dictionary<Type, string>
	{
		{ typeof(Rook), "R" },
		{ typeof(Knight), "T" },
		{ typeof(Bishop), "B" },
		{ typeof(King), "K" },
		{ typeof(Queen), "Q" },
		{ typeof(BlackPawn), "P" },
		{ typeof(WhitePawn), "P" }
		//{ typeof(EmptyPiece), "-" }
	};
}
