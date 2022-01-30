using System;
using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class ClockTests
{
	[Test]
	public void ShouldStartWithZeroElapsedTime()
	{
		var clock = new Clock(new TestDateTimeProvider());
		Assert.AreEqual(TimeSpan.Zero, clock.CurrentElapsedTime);
	}

	[Test]
	public void ShouldNotChangeElapsedTimeWhenItIsNotTicking()
	{
		var clock = new Clock(new TestDateTimeProvider());
		Assert.AreEqual(TimeSpan.Zero, clock.CurrentElapsedTime);
	}

	[Test]
	public void ShouldProvideCorrectElapsedTimeWhenItIsTicking()
	{
		var previousElapsedTime = TimeSpan.FromSeconds(150);
		var elapsedSinceStart = TimeSpan.FromSeconds(70);
		var expectedCurrentElapsedTime = previousElapsedTime + elapsedSinceStart;

		var dateTimeProviderStub = new TestDateTimeProvider(elapsedSince: startDateTime => elapsedSinceStart);
		var clock = new Clock(previousElapsedTime: previousElapsedTime, startDateTimeUtc: DateTime.MinValue, ticking: true, dateTimeProviderStub);
		Assert.AreEqual(expectedCurrentElapsedTime, clock.CurrentElapsedTime);
	}

	[Test]
	public void ShouldProvideCorrectElapsedTimeAfterStartStop()
	{
		var previousElapsedTime = TimeSpan.FromSeconds(150);
		var elapsedSinceStart = TimeSpan.FromSeconds(70);
		var expectedCurrentElapsedTime = previousElapsedTime + elapsedSinceStart;

		var dateTimeProviderStub = new TestDateTimeProvider(elapsedSince: startDateTime => elapsedSinceStart);
		var clock = new Clock(previousElapsedTime: previousElapsedTime, startDateTimeUtc: DateTime.MinValue, ticking: true, dateTimeProviderStub);
		Assert.AreEqual(expectedCurrentElapsedTime, clock.CurrentElapsedTime);

		clock.Stop();
		Assert.AreEqual(expectedCurrentElapsedTime, clock.CurrentElapsedTime);

		clock.Start();
		expectedCurrentElapsedTime = expectedCurrentElapsedTime + elapsedSinceStart;
		Assert.AreEqual(expectedCurrentElapsedTime, clock.CurrentElapsedTime);
	}
}
