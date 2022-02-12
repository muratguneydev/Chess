namespace Chess.Api.Request;

public record SessionIdRequest
{
	public SessionIdRequest(string value)
	{
		this.Value = value;
	}

	public string Value { get; }
}