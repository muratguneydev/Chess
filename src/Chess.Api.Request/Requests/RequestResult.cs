namespace Chess.Api.Request;

public abstract record RequestResult
{
	public RequestResult(Request request)
	{
		this.Request = request;
	}

	public Request Request { get; }
	public abstract string Result { get; }
}
