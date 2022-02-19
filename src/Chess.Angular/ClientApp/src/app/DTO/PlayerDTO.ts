import { Color } from "./Color";

export interface PlayerDTO {
	color: Color;
	name: string;
	isReady: boolean;
	elapsedSeconds: number;
}

