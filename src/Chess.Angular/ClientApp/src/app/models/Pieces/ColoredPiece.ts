import { Color } from "src/app/models/Color";
import { Piece } from "./Piece";


export class ColoredPiece implements Piece {

	constructor(private piece: Piece, private color: Color) {
		console.log('Piece string color:' + color);

	}
	name: string = this.piece.name;
	

	FENString = this.color == Color.White ? this.piece.FENString.toUpperCase() : this.piece.FENString.toLowerCase();
}
