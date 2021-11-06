namespace Chess.Console;

public class InformationView : View
{
	private readonly InformationViewModel informationViewModel;
	private readonly ConsoleWriterFactory consoleWriterFactory;

	public InformationView(InformationViewModel informationViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.informationViewModel = informationViewModel;
		this.consoleWriterFactory = consoleWriterFactory;
	}

	public override void Display()
	{
		this.consoleWriterFactory
			.Get(ConsoleColor.Black, ConsoleColor.White)
			.WriteLine(this.informationViewModel.Information);
	}
}
