import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";


export interface ReadyRequest extends Request {
	//new(sessionId: SessionIdRequest): ReadyRequest;
	SessionId: SessionIdRequest;
}
