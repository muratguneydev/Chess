import { EmptySessionIdDTO } from "../DTO/EmptySessionIdDTO";
import { SessionIdRequest } from "./SessionIdRequest";
import { Request } from "./Request";


export class EmptyRequest implements Request {
	constructor() {
		this.SessionId = new EmptySessionIdDTO();
		this.RequestType = "-";
	}

	SessionId: SessionIdRequest;
	RequestType: string;
}
