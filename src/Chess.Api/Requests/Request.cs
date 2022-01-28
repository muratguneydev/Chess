namespace Chess.Api.Requests;

public abstract record Request
{
	public abstract SessionId SessionId { get; }
	public virtual string RequestType => this.GetType().Name;
}