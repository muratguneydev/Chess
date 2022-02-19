import { CellDTO } from "./CellDTO";
import { BoardDTO } from "./BoardDTO";


export class EmptyBoardDTO implements BoardDTO {

	constructor() {
		this.cells = [];
	}

	cells: CellDTO[];
}
