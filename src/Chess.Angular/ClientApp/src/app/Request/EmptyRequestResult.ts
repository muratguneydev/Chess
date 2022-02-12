import { EmptyRequest } from "./EmptyRequest";
import { Request } from "./Request";
import { RequestResult } from "./RequestResult";


export class EmptyRequestResult implements RequestResult {

	constructor() {
		this.Request = new EmptyRequest();
		this.Result = "-";
	}

	Request: Request;
	Result: string;
}
