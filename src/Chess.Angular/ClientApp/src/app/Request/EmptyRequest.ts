import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";
import { EmptySessionIdRequest } from "./EmptySessionIdRequest";


export class EmptyRequest implements Request {
	constructor() {
		this.sessionId = new EmptySessionIdRequest();
		this.requestType = "-";
	}

	sessionId: SessionIdRequest;
	requestType: string;
}
