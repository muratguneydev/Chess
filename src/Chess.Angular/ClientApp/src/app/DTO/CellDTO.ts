import { PieceDTO } from "./PieceDTO";


export interface CellDTO {
	//new(x: number, y: number, piece: PieceDTO): CellDTO;
	//new(x: number, y: number): CellDTO;

	X: number;
	Y: number;
	Row: string;
	Column: string;
	Piece: PieceDTO;
}
