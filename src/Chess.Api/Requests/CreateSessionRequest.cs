namespace Chess.Api.Requests;

public record CreateSessionRequest : Request
{
	public CreateSessionRequest(SessionId sessionId)
	{
		this.SessionId = sessionId;
	}

	public override SessionId SessionId { get; }
}
