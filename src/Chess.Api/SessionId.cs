using Chess.Api.DTO;
using Chess.Api.Requests;

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
}
