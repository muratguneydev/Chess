using NUnit.Framework;

namespace Chess.Game.Tests.Helpers;

public static class SessionTestHelper
{
	public static Session Create(WhitePlayer? playerWhite = default(WhitePlayer), BlackPlayer? playerBlack = default(BlackPlayer),
		Board? board = null)
	{
		playerWhite = playerWhite ?? PlayerTestHelper.CreateWhitePlayer();
		playerBlack = playerBlack ?? PlayerTestHelper.CreateBlackPlayer();
		board = board ?? BoardTestHelper.Create();

		var sessionPlayers = new SessionPlayersTestBuilder()
			.WithBlackPlayer(playerBlack)
			.WithWhitePlayer(playerWhite)
			.Build();

		return new Session(sessionPlayers, SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(), board);
	}

	public static void AssertIsNotValidMove(Move move)
	{
		Assert.IsFalse(move.IsValid);
	}

	public static void AssertIsValidMove(Move move)
	{
		Assert.IsTrue(move.IsValid);
	}
}
