namespace Chess.Api.Requests;

public record SessionId
{
	public SessionId(string value)
	{
		this.Value = value;
	}

	public string Value { get; }
}