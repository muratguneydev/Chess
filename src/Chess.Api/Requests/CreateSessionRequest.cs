namespace Chess.Api.Requests;

public record CreateSessionRequest : Request
{
	public CreateSessionRequest(SessionIdRequest sessionId)
	{
		this.SessionId = sessionId;
	}

	public override SessionIdRequest SessionId { get; }
}
