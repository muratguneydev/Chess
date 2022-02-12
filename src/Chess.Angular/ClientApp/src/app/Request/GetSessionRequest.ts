import { SessionIdRequest } from "./SessionIdRequest";


export interface GetSessionRequest extends Request {
	new(sessionId: SessionIdRequest): GetSessionRequest;

	SessionId: SessionIdRequest;
}
