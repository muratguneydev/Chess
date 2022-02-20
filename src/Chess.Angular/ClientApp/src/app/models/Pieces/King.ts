import { Piece } from "./Piece";


export class King implements Piece {
	constructor(public name: string) {
		
	}
	public FENString = 'K';
}
