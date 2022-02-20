import { Color } from "../models/Color";
import { PlayerDTO } from "./PlayerDTO";


export class EmptyPlayerDTO implements PlayerDTO {

	constructor() {
		this.color = Color.None;
		this.name = "-";
		this.isReady = false;
		this.elapsedSeconds = 0;
	}

	color: Color;
	name: string;
	isReady: boolean;
	elapsedSeconds: number;

}
