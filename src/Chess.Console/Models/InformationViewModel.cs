namespace Chess.Console;

public class InformationViewModel
{
	public InformationViewModel(string information)
	{
		this.Information = information;
	}

	public string Information { get; }
}