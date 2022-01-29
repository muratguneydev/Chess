namespace Chess.Api.Requests;

public abstract record Request
{
	public abstract SessionIdRequest SessionId { get; }
	public virtual string RequestType => this.GetType().Name;
}