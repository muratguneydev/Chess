import { SessionIdRequest } from "./SessionIdRequest";


export class EmptySessionIdRequest implements SessionIdRequest {
	constructor() {
		this.Value = "-";
	}

	Value: string;
}
