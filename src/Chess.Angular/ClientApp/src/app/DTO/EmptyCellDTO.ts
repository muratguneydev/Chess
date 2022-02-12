import { EmptyPieceDTO } from "./EmptyPieceDTO";
import { PieceDTO } from "./PieceDTO";
import { CellDTO } from "./CellDTO";


export class EmptyCellDTO implements CellDTO {

	constructor() {
		this.X = 0;
		this.Y = 0;
		this.Row = "-";
		this.Column = "-";
		this.Piece = new EmptyPieceDTO();
	}
	X: number;
	Y: number;
	Row: string;
	Column: string;
	Piece: PieceDTO;

}
