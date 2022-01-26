namespace Chess.Api.Controllers;

public record EmptyBoardSerializable : BoardSerializable
{
	private static EmptyBoardSerializable emptyBoardSerializable = new EmptyBoardSerializable();

	private EmptyBoardSerializable()
		: base(Enumerable.Empty<CellSerializable>())
	{
	}

	public static EmptyBoardSerializable BoardSerializable => emptyBoardSerializable;
}