using NUnit.Framework;

namespace Chess.Game.Tests;

public class MoveStrategyTestData : TestCaseData
{
	public MoveStrategyTestData(Move fromTo)
		: base(fromTo)
	{
		
	}
}
