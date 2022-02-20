import { Piece } from "./Piece";


export class Pawn implements Piece {
	constructor(public name: string) {
		
	}
	public FENString = 'P';
}
