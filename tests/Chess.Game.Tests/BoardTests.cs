using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BoardTests
{
	[Test]
	public void ShouldGetPiecesInCoordinatesCorrectly()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);

		var a1Piece = new WhitePieceDecorator(new Rook(), session, board, board.a1);
		board.a1.Initialize(a1Piece);

		var a3Piece = new BlackPieceDecorator(new Knight(), session, board, board.a3);
		board.a3.Initialize(a3Piece);

		var a5Piece = new WhitePieceDecorator(new King(), session, board, board.a5);
		board.a5.Initialize(a5Piece);
		
		var a7Piece = new BlackPieceDecorator(new Queen(), session, board, board.a7);
		board.a7.Initialize(a7Piece);

		var actualPieces = board.GetPiecesInCoordinates(new[] {
			board.a1.Coordinate,
			board.a3.Coordinate,
			board.a5.Coordinate,
			board.a7.Coordinate
		});

		CollectionAssert.AreEquivalent(new[] { a1Piece, a3Piece, a5Piece, a7Piece as IBoardPiece }, actualPieces);
	}

	[Test]
	public void ShouldUpdatePieceLocationsAfterMove()
	{
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create(session);
		board.SetOpeningPosition();

		var move = board.a2.Move(board.a4);
		CellTestHelper.AssertIsValidMove(move);//a2-a4		
		session.Next(move);

		move = board.b7.Move(board.b5);
		CellTestHelper.AssertIsValidMove(move);//b7-b5
		session.Next(move);

		move = board.a4.Move(board.b5);
		CellTestHelper.AssertIsValidMove(move);//a4-b5
	}
}
