namespace Chess.Api.DTO;

public record SessionIdDTO
{
	public SessionIdDTO(Guid id)
	{
		this.Value = id.ToString();
	}

	public SessionIdDTO(string idString)
	{
		this.Value = idString;
	}

	public string Value { get; }
}
