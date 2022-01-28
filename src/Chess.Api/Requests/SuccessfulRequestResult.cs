namespace Chess.Api.Requests;

public record SuccessfulRequestResult : RequestResult
{
	public SuccessfulRequestResult(Request request)
		: base(request)
	{
		
	}

	public override string Result => "Successful";
}