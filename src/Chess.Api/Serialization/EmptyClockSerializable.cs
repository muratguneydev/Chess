namespace Chess.Api.Controllers;

public record EmptyClockSerializable : ClockSerializable
{
	private static EmptyClockSerializable emptyClockSerializable = new EmptyClockSerializable();

	private EmptyClockSerializable()
		: base(TimeSpan.Zero, DateTime.UtcNow, false)
	{
	}

	public static EmptyClockSerializable ClockSerializable => emptyClockSerializable;
}