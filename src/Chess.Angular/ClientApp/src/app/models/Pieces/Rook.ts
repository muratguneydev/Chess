import { Piece } from "./Piece";

export class Rook implements Piece {
	constructor(public name: string) {
		
	}
	public FENString = 'R';
}
