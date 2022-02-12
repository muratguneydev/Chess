import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";


export interface RegisterRequest extends Request {
	new(sessionId: SessionIdRequest, whitePlayerName: string, blackPlayerName: string): RegisterRequest;

	SessionId: SessionIdRequest;
	WhitePlayerName: string;
	BlackPlayerName: string;
}
