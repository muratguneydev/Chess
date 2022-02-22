import { CellDTO } from "../DTO/CellDTO";
import { Piece } from "./Pieces/Piece";
import { PieceFactory } from "./Pieces/PieceFactory";

export class Cell {
	constructor(private cellDTO: CellDTO, private pieceFactory: PieceFactory) {
	}

	x: number = this.cellDTO.x;
	y: number = this.cellDTO.y;
	row: string = this.cellDTO.row;
	column: string = this.cellDTO.column;
	piece: Piece = this.pieceFactory.Get(this.cellDTO.piece);
}

