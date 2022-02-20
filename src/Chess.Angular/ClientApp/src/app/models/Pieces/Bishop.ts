import { Piece } from "./Piece";

export class Bishop implements Piece {
	constructor(public name: string) {
		
	}
	public FENString = 'B';
}
