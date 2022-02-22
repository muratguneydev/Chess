using NUnit.Framework;

namespace Chess.Game.Tests.Helpers;

public static class SessionTestHelper
{
	public static Session Create(WhitePlayer? playerWhite = default(WhitePlayer), BlackPlayer? playerBlack = default(BlackPlayer),
		Board? board = null, MoveHistory? moveHistory = null)
	{
		playerWhite = playerWhite ?? PlayerTestHelper.CreateWhitePlayer();
		playerBlack = playerBlack ?? PlayerTestHelper.CreateBlackPlayer();
		board = board ?? BoardTestHelper.Create();
		moveHistory = moveHistory ?? MoveHistoryTestHelper.Create(board);

		var sessionPlayers = new SessionPlayersTestBuilder()
			.WithBlackPlayer(playerBlack)
			.WithWhitePlayer(playerWhite)
			.Build();

		return new Session(sessionPlayers, SessionPlayerRegistrarTestHelper.Create(), SessionStateMachineTestHelper.CreateDummy(),
			board, moveHistory);
	}

	public static Session GetStartedSession(SessionPlayers? sessionPlayers = null)
	{
		var session = GetStartedSessionWithEmptyBoard(sessionPlayers);
		session.Board.SetOpeningPosition();
		return session;
	}

	public static Session GetStartedSessionWithEmptyBoard(SessionPlayers? sessionPlayers = null)
	{
		sessionPlayers = sessionPlayers ?? SessionPlayersTestHelper.Create();
		var board = BoardTestHelper.Create();
		var session = new Session(sessionPlayers, SessionPlayerRegistrarTestHelper.Create(),
			SessionStateMachineTestHelper.Create(), board, MoveHistoryTestHelper.Create(board));
		session.RegisterBlackPlayer(sessionPlayers.BlackPlayer);
		session.RegisterWhitePlayer(sessionPlayers.WhitePlayer);
		session.SetBlackPlayerReady();
		session.SetWhitePlayerReady();

		session.Start();

		return session;
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
