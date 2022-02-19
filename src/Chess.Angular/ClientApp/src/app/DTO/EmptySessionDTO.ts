import { RequestResult } from "../Request/RequestResult";
import { BoardDTO } from "./BoardDTO";
import { Color } from "./Color";
import { EmptySessionIdDTO } from "./EmptySessionIdDTO";
import { MoveDTO } from "./MoveDTO";
import { PlayerDTO } from "./PlayerDTO";
import { SessionIdDTO } from "./SessionIdDTO";
import { SessionDTO } from "./SessionDTO";
import { EmptyPlayerDTO } from "./EmptyPlayerDTO";
import { EmptyRequestResult } from "../Request/EmptyRequestResult";
import { EmptyBoardDTO } from "./EmptyBoardDTO";


export class EmptySessionDTO implements SessionDTO {

	constructor() {
		var emptyPlayer = new EmptyPlayerDTO();
		this.board = new EmptyBoardDTO();
		this.moveHistory = [];
		this.whitePlayer = emptyPlayer;
		this.blackPlayer = emptyPlayer;
		this.currentPlayer = emptyPlayer;
		this.waitingPlayer = emptyPlayer;
		this.playTurnColor = Color.None;
		this.currentState = "-";
		this.id = new EmptySessionIdDTO();
		this.lastRequest = new EmptyRequestResult();
	}

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
	isEmpty: boolean = true;
}
