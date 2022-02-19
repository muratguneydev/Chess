import { RequestResult } from "../Request/RequestResult";
import { BoardDTO } from "./BoardDTO";
import { Color } from "./Color";
import { MoveDTO } from "./MoveDTO";
import { PlayerDTO } from "./PlayerDTO";
import { SessionIdDTO } from "./SessionIdDTO";


export interface SessionDTO {
	board: BoardDTO;
	moveHistory: MoveDTO[];
	whitePlayer: PlayerDTO;
	blackPlayer: PlayerDTO;
	currentPlayer: PlayerDTO;
	waitingPlayer: PlayerDTO;
	playTurnColor: Color;
	currentState: string;
	id: SessionIdDTO;
	lastRequest: RequestResult;
	isEmpty: boolean;
}
