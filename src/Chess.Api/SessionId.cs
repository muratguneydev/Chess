using Chess.Api.Request;

namespace Chess.Api;

public record SessionId
{
	public SessionId(Guid id)
	{
		this.Value = id.ToString();
	}

	public SessionId(string idString)
	{
		this.Value = idString;
	}

	public SessionId(SessionIdRequest sessionIdRequest)
	{
		this.Value = sessionIdRequest.Value;
	}

	public SessionId(SessionIdDTO sessionIdDTO)
	{
		this.Value = sessionIdDTO.Value;
	}

	public string Value { get; }

	public override string ToString()
	{
		return $"Session Id:{this.Value}";
	}
}
