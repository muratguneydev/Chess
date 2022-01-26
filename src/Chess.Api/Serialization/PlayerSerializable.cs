using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record PlayerSerializable
{
	[JsonConstructor]
	public PlayerSerializable(Color color, string name)
	{
		this.Color = color;
		this.Name = name;

		//public TimeSpan ElapsedTime => this.clock.ElapsedTime;
	}

	public Color Color { get; }
	public string Name { get; }
	public virtual bool IsEmpty => this.Color == EmptyPlayerSerializable.PlayerSerializable.Color && this.Name == EmptyPlayerSerializable.PlayerSerializable.Name;
}
