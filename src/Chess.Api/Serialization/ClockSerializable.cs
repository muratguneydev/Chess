using System.Text.Json.Serialization;
using Chess.Game;

namespace Chess.Api.Controllers;

public record ClockSerializable
{
	[JsonConstructor]
	public ClockSerializable(TimeSpan previousElapsedTime, DateTime startDateTimeUtc, bool ticking)
	{
		this.PreviousElapsedTime = previousElapsedTime;
		this.StartDateTimeUtc = startDateTimeUtc;
		this.Ticking = ticking;
	}

	public TimeSpan PreviousElapsedTime { get; }
	public DateTime StartDateTimeUtc { get; }
	public bool Ticking { get; }

	public IClock Convert()
	{
		return new Clock(this.PreviousElapsedTime, this.StartDateTimeUtc, this.Ticking, new DateTimeProvider());
	}

	public static ClockSerializable Create(IClock clock)
	{
		return new ClockSerializable(clock.PreviousElapsedTime, clock.StartDateTimeUtc, clock.Ticking);
	}
}