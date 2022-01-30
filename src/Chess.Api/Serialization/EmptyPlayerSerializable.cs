using Chess.Game;

namespace Chess.Api.Controllers;

public record EmptyPlayerSerializable : PlayerSerializable
{
	private static EmptyPlayerSerializable emptyPlayerSerializable = new EmptyPlayerSerializable();

	private EmptyPlayerSerializable()
		: base(Color.None, string.Empty, EmptyClockSerializable.ClockSerializable)
	{
	}

	public static EmptyPlayerSerializable PlayerSerializable => emptyPlayerSerializable;
}
