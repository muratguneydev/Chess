import { SessionIdRequest } from "./SessionIdRequest";


export class EmptySessionIdRequest implements SessionIdRequest {
	constructor() {
		this.value = "-";
	}

	value: string;
}
