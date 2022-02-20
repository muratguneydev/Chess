import { PieceDTO } from "src/app/DTO/PieceDTO";
import { Bishop } from "./Bishop";
import { ColoredPiece } from "./ColoredPiece";
import { EmptyPiece } from "./EmptyPiece";
import { King } from "./King";
import { Knight } from "./Knight";
import { Pawn } from "./Pawn";
import { Piece } from "./Piece";
import { Queen } from "./Queen";
import { Rook } from "./Rook";

export class PieceFactory {
	public Get(pieceDTO: PieceDTO) : Piece {
		//console.log('Piece color:' + pieceDTO.color);

		switch (pieceDTO.name)
		{
			case "":
				return new EmptyPiece(pieceDTO.name);
			case "Pawn":
				return new ColoredPiece(new Pawn(pieceDTO.name), pieceDTO.color);
			case "Rook":
				return new ColoredPiece(new Rook(pieceDTO.name), pieceDTO.color);
			case "Knight":
				return new ColoredPiece(new Knight(pieceDTO.name), pieceDTO.color);
			case "Bishop":
				return new ColoredPiece(new Bishop(pieceDTO.name), pieceDTO.color);
			case "Queen":
				return new ColoredPiece(new Queen(pieceDTO.name), pieceDTO.color);
			case "King":
				return new ColoredPiece(new King(pieceDTO.name), pieceDTO.color);
		}
		throw 'Unknown chess piece received:' + JSON.stringify(pieceDTO);
	}


}


