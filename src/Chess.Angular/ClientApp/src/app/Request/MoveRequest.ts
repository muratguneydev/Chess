import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";
import { CellRequest } from "./CellRequest";

export class MoveRequest implements Request {
	constructor(public sessionId: SessionIdRequest, public from: CellRequest, public to: CellRequest) {
		//super(sessionId, "MoveRequest");
		
	}
	requestType: string = "MoveRequest";
	//new(sessionId: SessionIdRequest, from: CellRequest, to: CellRequest): MoveRequest;
	
	
	//sessionId: SessionIdRequest;
	// from: CellRequest;
	// to: CellRequest;
}
