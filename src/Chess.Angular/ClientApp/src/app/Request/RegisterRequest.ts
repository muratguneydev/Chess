import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";


export class RegisterRequest implements Request {
	//new(sessionId: SessionIdRequest, whitePlayerName: string, blackPlayerName: string): RegisterRequest;
	constructor(public sessionId: SessionIdRequest, public whitePlayerName: string, public 	blackPlayerName: string) {
		
	}

	requestType: string = "RegisterRequest";
}
