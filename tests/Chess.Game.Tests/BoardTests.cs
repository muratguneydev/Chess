using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BoardTests
{
	[Test]
	public void ShouldGetPiecesInCoordinatesCorrectly()
	{
		var board = BoardTestHelper.Create();

		var a1Piece = WhitePieceDecoratorTestHelper.Create(new Rook());
		board.a1.SetPiece(a1Piece);

		var a3Piece = BlackPieceDecoratorTestHelper.Create(new Knight());
		board.a3.SetPiece(a3Piece);

		var a5Piece = WhitePieceDecoratorTestHelper.Create(new King());
		board.a5.SetPiece(a5Piece);
		
		var a7Piece = BlackPieceDecoratorTestHelper.Create(new Queen());
		board.a7.SetPiece(a7Piece);

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
		var session = SessionTestHelper.GetStartedSession();

		var move = session.Board.a2.GetMove(session.Board.a4);
		MoveTestHelper.AssertIsValidMove(move);//a2-a4		
		session.Move(move);

		move = session.Board.b7.GetMove(session.Board.b5);
		MoveTestHelper.AssertIsValidMove(move);//b7-b5
		session.Move(move);

		move = session.Board.a4.GetMove(session.Board.b5);
		MoveTestHelper.AssertIsValidMove(move);//a4-b5
	}
}
