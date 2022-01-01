using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class SessionPlayerRegistrarTests
{
	[Test]
	public void ShouldReturnRegisteredWhenBothBlackAndWhitePlayersRegistered()
	{
		var sessionPlayerRegistrar = SessionPlayerRegistrarTestHelper.Create();

		sessionPlayerRegistrar.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer());
		sessionPlayerRegistrar.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer());

		Assert.IsTrue(sessionPlayerRegistrar.AllPlayersRegistered);
	}

	[Test]
	public void ShouldNotReturnRegisteredWhenWhitePlayerIsNotRegistered()
	{
		var sessionPlayerRegistrar = SessionPlayerRegistrarTestHelper.Create();

		sessionPlayerRegistrar.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer());

		Assert.IsFalse(sessionPlayerRegistrar.AllPlayersRegistered);
	}

	[Test]
	public void ShouldNotReturnRegisteredWhenBlackPlayerIsNotRegistered()
	{
		var sessionPlayerRegistrar = SessionPlayerRegistrarTestHelper.Create();

		sessionPlayerRegistrar.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer());

		Assert.IsFalse(sessionPlayerRegistrar.AllPlayersRegistered);
	}

	[Test]
	public void ShouldInvokeRegisteredEventWhenBothPlayersRegistered()
	{
		bool isEventCallbackInvoked = false;
		var sessionPlayerRegistrar = SessionPlayerRegistrarTestHelper.Create();
		sessionPlayerRegistrar.AddPlayersRegisteredEventCallback(sessionPlayers => isEventCallbackInvoked = true);
		sessionPlayerRegistrar.RegisterBlackPlayer(PlayerTestHelper.CreateBlackPlayer());
		sessionPlayerRegistrar.RegisterWhitePlayer(PlayerTestHelper.CreateWhitePlayer());

		Assert.IsTrue(isEventCallbackInvoked);
	}
}