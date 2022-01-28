namespace Chess.Api.Requests;

public record RegisterRequest : Request
{
	public RegisterRequest(SessionId sessionId)
	{
		this.SessionId = sessionId;
		
	}

	public override SessionId SessionId { get; }
	
}