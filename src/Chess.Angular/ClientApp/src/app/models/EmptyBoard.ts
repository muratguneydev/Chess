import { Board } from "./Board";
import { EmptyBoardDTO } from "../DTO/EmptyBoardDTO";
import { PieceFactory } from "./Pieces/PieceFactory";


export class EmptyBoard extends Board {

	constructor() {
		super(new EmptyBoardDTO(), new PieceFactory());

	}
}
