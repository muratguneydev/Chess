import { SessionIdRequest } from "./SessionIdRequest";


export interface GetSessionRequest extends Request {
	new(sessionId: SessionIdRequest): GetSessionRequest;

	sessionId: SessionIdRequest;
}
