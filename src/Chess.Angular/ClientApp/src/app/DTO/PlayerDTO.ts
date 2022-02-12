import { Color } from "./Color";

export interface PlayerDTO {
	Color: Color;
	Name: string;
	IsReady: boolean;
	ElapsedSeconds: number;
}

