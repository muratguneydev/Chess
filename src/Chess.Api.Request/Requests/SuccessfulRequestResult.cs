namespace Chess.Api.Request;

public record SuccessfulRequestResult : RequestResult
{
	public SuccessfulRequestResult(Request request)
		: base(request)
	{
		
	}

	public override string Result => "Successful";
}