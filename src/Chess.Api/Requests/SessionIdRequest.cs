namespace Chess.Api.Requests;

public record SessionIdRequest
{
	public SessionIdRequest(string value)
	{
		this.Value = value;
	}

	public string Value { get; }
}