using System;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class MoveUsingBoardTestData : TestCaseData
{
	public MoveUsingBoardTestData(Func<Board,Move> getMoveWithBoard)
		: base(getMoveWithBoard)
	{
		
	}
}

public class MoveWithBlockingPieceInTheMiddleUsingBoardTestData : TestCaseData
{
	public MoveWithBlockingPieceInTheMiddleUsingBoardTestData(Func<Board,Move> getMoveWithBoard, Func<Board, Cell> getBlockingCell)
		: base(getMoveWithBoard, getBlockingCell)
	{
		
	}
}