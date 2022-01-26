namespace Chess.Api.Controllers;

public record EmptySessionSerializable : SessionSerializable
{
	private static EmptySessionSerializable emptySessionSerializable = new EmptySessionSerializable();

	private EmptySessionSerializable()
		: base(EmptyPlayerSerializable.PlayerSerializable, EmptyPlayerSerializable.PlayerSerializable, EmptyBoardSerializable.BoardSerializable,
			new SessionStateSerializable("SessionStateRegistration"))
	{
	}

	public static EmptySessionSerializable SessionSerializable => emptySessionSerializable;
}