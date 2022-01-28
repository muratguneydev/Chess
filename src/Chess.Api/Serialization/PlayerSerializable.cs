using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record PlayerSerializable
{
	[JsonConstructor]
	public PlayerSerializable(Color color, string name, int elapsedTimeInSeconds)
	{
		this.Color = color;
		this.Name = name;
		this.ElapsedTimeInSeconds = elapsedTimeInSeconds;
	}

	public Color Color { get; }
	public string Name { get; }
	public int ElapsedTimeInSeconds { get; }

	public virtual bool IsEmpty => this.Color == EmptyPlayerSerializable.PlayerSerializable.Color && this.Name == EmptyPlayerSerializable.PlayerSerializable.Name;
}
