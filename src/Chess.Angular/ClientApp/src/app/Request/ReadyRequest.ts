import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";


export class ReadyRequest implements Request {
	//new(sessionId: SessionIdRequest): ReadyRequest;
	constructor(public sessionId: SessionIdRequest) {
		
	}

	requestType: string = "ReadyRequest";

}
