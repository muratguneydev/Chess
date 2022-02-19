import { Request } from "./Request";

export interface RequestResult {
	//new(request: Request): RequestResult;

	request: Request;
	result: string;
}

