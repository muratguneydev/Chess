import { CellDTO } from "../DTO/CellDTO";
import { BoardDTO } from "../DTO/BoardDTO";
import { Cell } from "./Cell";
import { PieceFactory } from "./Pieces/PieceFactory";

export class Board {

	constructor(private boardDTO: BoardDTO, private pieceFactory: PieceFactory) {
	}

	public rows: Array<Cell[]> = Object.values(
		this.boardDTO.cells.reduce((g: any, cell: CellDTO) => {
										var rowId = cell.y;
										g[rowId] = g[rowId] || []; //Check the value exists, if not assign a new array
										g[rowId].push(new Cell(cell, this.pieceFactory)); //Push the new value to the array
										return g; //Very important! you need to return the value of g or it will become undefined on the next pass
									}, {})
								);

	public FENString: string = this.reverseString(
									this.squeezeFenEmptySquares(
										this.rows
												.map(row => this.reverseString(this.JoinFENCharacters(row)))
												.join('/')
									)
								) + " w KQkq - 0 1";
	
	public GetCell(x: number, y: number) : Cell {
		return this.rows[y][x];
	}

	private JoinFENCharacters(row: Cell[]): string {
		return row
			.map(cell => cell.piece.FENString)
			.join('');
	}

	private squeezeFenEmptySquares (fen: string) : string {
		return fen.replace(/11111111/g, '8')
		  .replace(/1111111/g, '7')
		  .replace(/111111/g, '6')
		  .replace(/11111/g, '5')
		  .replace(/1111/g, '4')
		  .replace(/111/g, '3')
		  .replace(/11/g, '2')
	  }

	private reverseString(str: string) : string{
		return str.split("").reverse().join("");
	}
}


