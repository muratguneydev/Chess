namespace Chess.Api.Requests;

public record GetSessionRequest : Request
{
	public GetSessionRequest(SessionIdRequest sessionId)
	{
		this.SessionId = sessionId;
	}

	public override SessionIdRequest SessionId { get; }
}