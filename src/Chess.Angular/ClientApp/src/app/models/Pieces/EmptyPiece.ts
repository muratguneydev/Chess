import { Piece } from "./Piece";


export class EmptyPiece implements Piece {
	constructor(public name: string) {
	}
	public FENString = '1';
}
