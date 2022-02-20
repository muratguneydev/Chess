import { Piece } from "./Piece";


export class Knight implements Piece {
	constructor(public name: string) {
		
	}
	public FENString = 'N';
}
