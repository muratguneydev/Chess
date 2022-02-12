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
		this.Board = new EmptyBoardDTO();
		this.MoveHistory = [];
		this.WhitePlayer = emptyPlayer;
		this.BlackPlayer = emptyPlayer;
		this.CurrentPlayer = emptyPlayer;
		this.WaitingPlayer = emptyPlayer;
		this.PlayTurnColor = Color.None;
		this.CurrentState = "-";
		this.Id = new EmptySessionIdDTO();
		this.LastRequest = new EmptyRequestResult();
	}

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
	IsEmpty: boolean = true;
}
