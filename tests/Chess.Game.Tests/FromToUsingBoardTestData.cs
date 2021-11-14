using System;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class FromToUsingBoardTestData : TestCaseData
{
	public FromToUsingBoardTestData(Func<Board,Move> getFromToWithBoard)
		: base(getFromToWithBoard)
	{
		
	}
}

public class FromToWithBlockingPieceInTheMiddleUsingBoardTestData : TestCaseData
{
	public FromToWithBlockingPieceInTheMiddleUsingBoardTestData(Func<Board,Move> getFromToWithBoard, Func<Board, Cell> getBlockingCell)
		: base(getFromToWithBoard, getBlockingCell)
	{
		
	}
}