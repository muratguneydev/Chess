using NUnit.Framework;
using System.Text.Json;
using Chess.Game;

namespace Chess.Api.Controllers;

public static class SessionComparer
{
	public static void Compare(Session expected, Session actual)
	{
		Assert.AreEqual(Serialize(expected), Serialize(actual));
	}

	private static string Serialize(Session session)
	{
		return JsonSerializer.Serialize(session);
	}
}
