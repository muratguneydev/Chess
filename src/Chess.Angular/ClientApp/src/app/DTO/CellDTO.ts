import { PieceDTO } from "./PieceDTO";


export interface CellDTO {
	//new(x: number, y: number, piece: PieceDTO): CellDTO;
	//new(x: number, y: number): CellDTO;

	x: number;
	y: number;
	row: string;
	column: string;
	piece: PieceDTO;
}
