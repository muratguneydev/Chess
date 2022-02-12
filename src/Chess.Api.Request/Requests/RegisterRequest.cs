namespace Chess.Api.Request;

public record RegisterRequest : Request
{
	public RegisterRequest(SessionIdRequest sessionId, string whitePlayerName, string blackPlayerName)
	{
		this.SessionId = sessionId;
		this.WhitePlayerName = whitePlayerName;
		this.BlackPlayerName = blackPlayerName;
	}

	public override SessionIdRequest SessionId { get; }
	public string WhitePlayerName { get; }
	public string BlackPlayerName { get; }
}
