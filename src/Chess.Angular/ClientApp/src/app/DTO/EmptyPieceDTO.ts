import { Color } from "../models/Color";
import { PieceDTO } from "./PieceDTO";


export class EmptyPieceDTO implements PieceDTO {
	constructor() {
		this.name = "-";
		this.color = Color.None;
	}
	name: string;
	color: Color;
}
