namespace Chess.Api.Request;

public abstract record Request
{
	public abstract SessionIdRequest SessionId { get; }
	public virtual string RequestType => this.GetType().Name;
}