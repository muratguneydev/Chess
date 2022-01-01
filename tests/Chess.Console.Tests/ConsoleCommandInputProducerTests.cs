using System.Linq;
using NUnit.Framework;

namespace Chess.Console.Tests;

public class ConsoleCommandInputProducerTests
{
	[Test]
	public void ShouldReturnValidMoveCommand()
	{
		var consoleReaderStub = new TestConsoleReader(new[] {"move:a2-a4", string.Empty});
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReaderStub,
			new ConsoleWriterFactory(), BoardViewModelTestHelper.Create());
		
		var commands = consoleCommandInputProducer.ToArray();
		Assert.IsInstanceOf<MoveCommand>(commands[0]);
		Assert.IsInstanceOf<ExitCommand>(commands[1]);
	}

	[Test]
	public void ShouldReturnBackCommand()
	{
		var consoleReaderStub = new TestConsoleReader(new[] {"back", string.Empty});
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReaderStub,
			new ConsoleWriterFactory(), BoardViewModelTestHelper.Create());
		
		var commands = consoleCommandInputProducer.ToArray();
		Assert.IsInstanceOf<TakeBackCommand>(commands[0]);
		Assert.IsInstanceOf<ExitCommand>(commands[1]);
	}

	[Test]
	public void ShouldReturnRegisterBlackPlayerCommand()
	{
		var consoleReaderStub = new TestConsoleReader(new[] {"registerblack:john doe", string.Empty});
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReaderStub,
			new ConsoleWriterFactory(), BoardViewModelTestHelper.Create());
		
		var commands = consoleCommandInputProducer.ToArray();
		Assert.IsInstanceOf<RegisterBlackCommand>(commands[0]);
		Assert.IsInstanceOf<ExitCommand>(commands[1]);
	}

	[Test]
	public void ShouldReturnRegisterWhitePlayerCommand()
	{
		var consoleReaderStub = new TestConsoleReader(new[] {"registerwhite:john doe", string.Empty});
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReaderStub,
			new ConsoleWriterFactory(), BoardViewModelTestHelper.Create());
		
		var commands = consoleCommandInputProducer.ToArray();
		Assert.IsInstanceOf<RegisterWhiteCommand>(commands[0]);
		Assert.IsInstanceOf<ExitCommand>(commands[1]);
	}

	[Test]
	public void ShouldReturnRegisterAnonymousCommand()
	{
		var consoleReaderStub = new TestConsoleReader(new[] {"anonymous", string.Empty});
		var consoleCommandInputProducer = new ConsoleCommandInputProducer(consoleReaderStub,
			new ConsoleWriterFactory(), BoardViewModelTestHelper.Create());
		
		var commands = consoleCommandInputProducer.ToArray();
		Assert.IsInstanceOf<RegisterAnonymousCommand>(commands[0]);
		Assert.IsInstanceOf<ExitCommand>(commands[1]);
	}

	private class TestConsoleReader : IConsoleReader
	{
		private int currentInputIndex;
		private readonly string[] inputsToReturn;

		public TestConsoleReader(string[] inputsToReturn)
		{
			this.inputsToReturn = inputsToReturn;
		}
		public string ReadLine()
		{
			return this.inputsToReturn[this.currentInputIndex++];
		}
	}
}