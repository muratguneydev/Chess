import { Board } from "./Board";
import { EmptyBoardDTO } from "../DTO/EmptyBoardDTO";


export class EmptyBoard extends Board {

	constructor() {
		super(new EmptyBoardDTO());

	}
}
