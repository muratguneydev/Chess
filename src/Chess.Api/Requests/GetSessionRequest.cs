namespace Chess.Api.Requests;

public record GetSessionRequest : Request
{
	public GetSessionRequest(SessionId sessionId)
	{
		this.SessionId = sessionId;
	}

	public override SessionId SessionId { get; }
}