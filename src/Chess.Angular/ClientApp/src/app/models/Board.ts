import { CellDTO } from "../DTO/CellDTO";
import { BoardDTO } from "../DTO/BoardDTO";

export class Board {

	constructor(private boardDTO: BoardDTO) {
	}

	public rows: Array<CellDTO[]> = Object.values(
		this.boardDTO.cells.reduce((g: any, cell: CellDTO) => {
										var rowId = cell.y;
										g[rowId] = g[rowId] || []; //Check the value exists, if not assign a new array
										g[rowId].push(cell); //Push the new value to the array
										return g; //Very important! you need to return the value of g or it will become undefined on the next pass
									}, {}));
}
