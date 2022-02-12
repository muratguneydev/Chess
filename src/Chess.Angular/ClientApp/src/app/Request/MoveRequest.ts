import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";
import { CellRequest } from "./CellRequest";

export interface MoveRequest extends Request {
	//new(sessionId: SessionIdRequest, from: CellRequest, to: CellRequest): MoveRequest;

	SessionId: SessionIdRequest;
	From: CellRequest;
	To: CellRequest;
}
