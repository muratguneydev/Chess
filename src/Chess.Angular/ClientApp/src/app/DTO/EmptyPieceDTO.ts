import { Color } from "./Color";
import { PieceDTO } from "./PieceDTO";


export class EmptyPieceDTO implements PieceDTO {
	constructor() {
		this.Name = "-";
		this.Color = Color.None;
	}
	Name: string;
	Color: Color;
}
