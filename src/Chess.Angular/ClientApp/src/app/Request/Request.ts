import { SessionIdRequest } from "./SessionIdRequest";

export interface Request {
	sessionId: SessionIdRequest;
	requestType: string;
}

