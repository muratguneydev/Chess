import { EmptyRequest } from "./EmptyRequest";
import { Request } from "./Request";
import { RequestResult } from "./RequestResult";


export class EmptyRequestResult implements RequestResult {

	constructor() {
		this.request = new EmptyRequest();
		this.result = "-";
	}

	request: Request;
	result: string;
}
