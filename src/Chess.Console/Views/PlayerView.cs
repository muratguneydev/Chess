namespace Chess.Console;

public class PlayerView : View
{
	private readonly PlayerViewModel playerViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public PlayerView(PlayerViewModel playerViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.playerViewModel = playerViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override void Display()
	{
		this.consoleWriterFactory
			.Get(ConsoleColor.Black, ConsoleColor.DarkYellow)
			.WriteLine(this.playerViewModel.Name);
	}
}
