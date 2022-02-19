import { SessionIdDTO } from "./SessionIdDTO";


export class EmptySessionIdDTO implements SessionIdDTO {

	constructor() {
		this.value = "-";
	}
	value: string;
}
