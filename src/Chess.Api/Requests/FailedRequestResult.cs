namespace Chess.Api.Requests;

public record FailedRequestResult : RequestResult
{
	public FailedRequestResult(Request request)
		: base(request)
	{
		
	}

	public override string Result => "Failed";
}
