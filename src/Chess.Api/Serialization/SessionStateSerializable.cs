using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record SessionStateSerializable
{
	[JsonConstructor]
	public SessionStateSerializable(string sessionState)
	{
		SessionState = sessionState;
	}

	public string SessionState { get; }

	public SessionState Convert()
	{
		var type = typeof(SessionState).Assembly.GetType(this.SessionState);
		if (type == null)
			throw new Exception($"Cannot deserialize session state from type:{this.SessionState};");
		var sessionState = Activator.CreateInstance(type) as SessionState;
		if (sessionState == null)
			throw new Exception($"Cannot deserialize session state from type:{this.SessionState};");

		return sessionState;
	}
}