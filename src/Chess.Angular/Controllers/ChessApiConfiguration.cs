namespace Chess.Angular.Controllers;

public class ChessApiConfiguration
{
	private readonly ChessApiConfigurationOptions chessApiConfigurationOptions;

	public ChessApiConfiguration(IConfiguration configuration)
	{
		this.chessApiConfigurationOptions = GetChessApiConfiguration(configuration);
	}
	public virtual string BaseUrl => this.chessApiConfigurationOptions.BaseUrl;
	public virtual string SessionEndPoint => $"{this.BaseUrl}/session";
	public virtual string MoveEndPoint => $"{this.BaseUrl}/move";
	public virtual string RegisterEndPoint => $"{this.BaseUrl}/register";
	public virtual string ReadyEndPoint => $"{this.BaseUrl}/ready";

	private static ChessApiConfigurationOptions GetChessApiConfiguration(IConfiguration configuration)
	{
		var chessApiConfigurationOptions = new ChessApiConfigurationOptions();
		configuration.GetSection(ChessApiConfigurationOptions.SectionName).Bind(chessApiConfigurationOptions);
		return chessApiConfigurationOptions;
	}
}

