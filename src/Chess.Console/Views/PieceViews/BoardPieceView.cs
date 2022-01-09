using Chess.Game;

namespace Chess.Console;

public abstract class BoardPieceView : View
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
	
	protected abstract string DisplayString { get; }

	private Dictionary<Color,IConsoleWriter> GetConsoleWriterMap()
	{
		var colorConsoleWriterMap =  new Dictionary<Color, IConsoleWriter>();
		colorConsoleWriterMap.Add(Color.Black, this.consoleWriterFactory.Get(ConsoleColor.Black,  ConsoleColor.Red));
		colorConsoleWriterMap.Add(Color.White, this.consoleWriterFactory.Get(ConsoleColor.Black,  ConsoleColor.White));
		colorConsoleWriterMap.Add(Color.None, this.consoleWriterFactory.Get(ConsoleColor.Black,  ConsoleColor.Gray));
		
		return colorConsoleWriterMap;
	}
}
