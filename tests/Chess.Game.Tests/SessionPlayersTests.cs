using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class SessionPlayersTests
{
	[Test]
	public void ShouldReturnReadyWhenBothBlackAndWhitePlayersReady()
	{
		var sessionPlayers = SessionPlayersTestHelper.Create();

		sessionPlayers.SetBlackPlayerReady();
		sessionPlayers.SetWhitePlayerReady();

		Assert.IsTrue(sessionPlayers.IsReady);
	}

	[Test]
	public void ShouldNotReturnReadyWhenWhitePlayerIsNotReady()
	{
		var sessionPlayers = SessionPlayersTestHelper.Create();
		sessionPlayers.SetBlackPlayerReady();

		Assert.IsFalse(sessionPlayers.IsReady);
	}

	[Test]
	public void ShouldNotReturnReadyWhenBlackPlayerIsNotRegistered()
	{
		var sessionPlayers = SessionPlayersTestHelper.Create();
		sessionPlayers.SetWhitePlayerReady();

		Assert.IsFalse(sessionPlayers.IsReady);
	}

	[Test]
	public void ShouldInvokeReadyEventWhenBothPlayersReady()
	{
		bool isEventCallbackInvoked = false;
		var sessionPlayers = SessionPlayersTestHelper.Create();
		sessionPlayers.AddPlayersReadyEventCallback(sessionPlayers => isEventCallbackInvoked = true);
		sessionPlayers.SetWhitePlayerReady();
		sessionPlayers.SetBlackPlayerReady();

		Assert.IsTrue(isEventCallbackInvoked);
	}
}
