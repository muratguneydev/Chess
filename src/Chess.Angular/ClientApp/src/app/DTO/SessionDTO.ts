import { RequestResult } from "../Request/RequestResult";
import { BoardDTO } from "./BoardDTO";
import { Color } from "./Color";
import { MoveDTO } from "./MoveDTO";
import { PlayerDTO } from "./PlayerDTO";
import { SessionIdDTO } from "./SessionIdDTO";


export interface SessionDTO {
	Board: BoardDTO;
	MoveHistory: MoveDTO[];
	WhitePlayer: PlayerDTO;
	BlackPlayer: PlayerDTO;
	CurrentPlayer: PlayerDTO;
	WaitingPlayer: PlayerDTO;
	PlayTurnColor: Color;
	CurrentState: string;
	Id: SessionIdDTO;
	LastRequest: RequestResult;
	IsEmpty: boolean;
}
