namespace Chess.Angular.Controllers;

public record ChessApiConfigurationOptions
{
	public const string SectionName = "ChessApi";

	public string BaseUrl { get; set; } = string.Empty;
}