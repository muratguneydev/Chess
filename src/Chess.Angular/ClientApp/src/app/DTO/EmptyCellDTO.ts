import { EmptyPieceDTO } from "./EmptyPieceDTO";
import { PieceDTO } from "./PieceDTO";
import { CellDTO } from "./CellDTO";


export class EmptyCellDTO implements CellDTO {

	constructor() {
		this.x = 0;
		this.y = 0;
		this.row = "-";
		this.column = "-";
		this.piece = new EmptyPieceDTO();
	}
	x: number;
	y: number;
	row: string;
	column: string;
	piece: PieceDTO;

}
