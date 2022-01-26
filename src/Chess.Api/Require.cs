namespace Chess.Api.Controllers;

public static class Require
{
	public static void NotNull(object value, string parameter)
	{
		if (value == null)
			throw new ArgumentException($"{parameter} cannot be null.");
	}
}
