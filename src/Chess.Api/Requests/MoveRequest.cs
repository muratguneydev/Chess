namespace Chess.Api.Requests;

public record MoveRequest : Request
{
	public MoveRequest(SessionIdRequest sessionId, CellRequest from, CellRequest to)
	{
		this.SessionId = sessionId;
		this.From = from;
		this.To = to;
	}

	public override SessionIdRequest SessionId { get; }
	public CellRequest From { get; }
	public CellRequest To { get; }
}
