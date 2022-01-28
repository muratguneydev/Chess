using Chess.Game;

namespace Chess.Api.Controllers;

public record EmptyPlayerSerializable : PlayerSerializable
{
	private static EmptyPlayerSerializable emptyPlayerSerializable = new EmptyPlayerSerializable();

	private EmptyPlayerSerializable()
		: base(Color.None, string.Empty, default(int))
	{
	}

	public static EmptyPlayerSerializable PlayerSerializable => emptyPlayerSerializable;
}