namespace Chess.Api.Requests;

public record ReadyRequest : Request
{
	public ReadyRequest(SessionIdRequest sessionId)
	{
		this.SessionId = sessionId;
	}

	public override SessionIdRequest SessionId { get; }
}