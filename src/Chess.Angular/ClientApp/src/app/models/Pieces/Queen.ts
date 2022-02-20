import { Piece } from "./Piece";


export class Queen implements Piece {
	constructor(public name: string) {
		
	}
	public FENString = 'Q';
}


