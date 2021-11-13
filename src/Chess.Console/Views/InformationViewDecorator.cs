namespace Chess.Console;

public class InformationViewDecorator : View
{
	private readonly View view;
	private readonly InformationView informationView;

	public InformationViewDecorator(View view, InformationViewModel informationViewModel, ConsoleWriterFactory consoleWriterFactory)
	{
		this.view = view;
		this.informationView = new InformationView(informationViewModel, consoleWriterFactory);
	}

	public override void Display()
	{
		this.informationView.Display();
		this.view.Display();
	}
}
