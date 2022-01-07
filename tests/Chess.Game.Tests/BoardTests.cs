using Chess.Game.Tests.Helpers;
using NUnit.Framework;

namespace Chess.Game.Tests;

public class BoardTests
{
	[Test]
	public void ShouldGetPiecesInCoordinatesCorrectly()
	{
		var board = BoardTestHelper.Create();

		var a1Piece = WhitePieceDecoratorTestHelper.Create(new Rook(), board);
		board.a1.SetPiece(a1Piece);

		var a3Piece = BlackPieceDecoratorTestHelper.Create(new Knight(), board);
		board.a3.SetPiece(a3Piece);

		var a5Piece = WhitePieceDecoratorTestHelper.Create(new King(), board);
		board.a5.SetPiece(a5Piece);
		
		var a7Piece = BlackPieceDecoratorTestHelper.Create(new Queen(), board);
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
		var session = SessionTestHelper.Create();
		var board = BoardTestHelper.Create();
		board.SetOpeningPosition();

		var move = board.a2.GetMove(board.a4);
		MoveTestHelper.AssertIsValidMove(move);//a2-a4		
		session.Move(move);

		move = board.b7.GetMove(board.b5);
		MoveTestHelper.AssertIsValidMove(move);//b7-b5
		session.Move(move);

		move = board.a4.GetMove(board.b5);
		MoveTestHelper.AssertIsValidMove(move);//a4-b5
	}
}
