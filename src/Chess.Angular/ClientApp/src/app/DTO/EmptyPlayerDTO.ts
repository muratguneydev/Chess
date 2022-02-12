import { Color } from "./Color";
import { PlayerDTO } from "./PlayerDTO";


export class EmptyPlayerDTO implements PlayerDTO {

	constructor() {
		this.Color = Color.None;
		this.Name = "-";
		this.IsReady = false;
		this.ElapsedSeconds = 0;
	}

	Color: Color;
	Name: string;
	IsReady: boolean;
	ElapsedSeconds: number;

}
