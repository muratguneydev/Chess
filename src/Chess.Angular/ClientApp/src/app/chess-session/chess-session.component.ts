import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SessionDTO } from '../DTO/SessionDTO';
import { EmptySessionDTO } from '../DTO/EmptySessionDTO';
import { EmptyBoard } from '../models/EmptyBoard';
import { Board } from '../models/Board';
import { MoveRequest } from '../Request/MoveRequest';
import { SessionIdRequest } from '../Request/SessionIdRequest';
import { CellRequest } from '../Request/CellRequest';
import { RegisterRequest } from '../Request/RegisterRequest';
import { ReadyRequest } from '../Request/ReadyRequest';

@Component({
  selector: 'app-chess-session',
  templateUrl: './chess-session.component.html'
})
export class ChessSessionComponent {
  public session: SessionDTO = new EmptySessionDTO();
  public board: Board = new EmptyBoard();
  public moveExpression: string = "";
  public whitePlayerName: string = "";
  public blackPlayerName: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  	public createSession() {
    	this.http
				.post<SessionDTO>(this.baseUrl + 'session', null)
				.subscribe(result => {
								this.session = result;
								this.board = new Board(this.session.board);
								console.log(result);
							},
							error => console.error(error));
  	}

	public register() {
		var registerRequest = new RegisterRequest(new SessionIdRequest(this.session.id.value), this.whitePlayerName, this.blackPlayerName);
		//console.log(moveRequest);
		this.http
				.put<SessionDTO>(this.baseUrl + 'register', registerRequest)
				.subscribe(result => {
								this.session = result;
								this.board = new Board(this.session.board);
								console.log(result);
							},
							error => console.error(error));
  	}

	public ready() {
		var readyRequest = new ReadyRequest(new SessionIdRequest(this.session.id.value));
		//console.log(moveRequest);
		this.http
				.put<SessionDTO>(this.baseUrl + 'ready', readyRequest)
				.subscribe(result => {
								this.session = result;
								this.board = new Board(this.session.board);
								console.log(result);
							},
							error => console.error(error));
  	}

  	public move() {
		var moveRequest = this.GetMoveRequest();
		console.log(moveRequest);
		this.http
				.put<SessionDTO>(this.baseUrl + 'move', moveRequest)
				.subscribe(result => {
								this.session = result;
								this.board = new Board(this.session.board);
								console.log(result);
							},
							error => console.error(error));
  	}

	private GetMoveRequest() : MoveRequest
	{
		// if (moveString == null)
		// 	throw new InvalidMoveStringException(string.Empty);
		var moveStringParts = this.moveExpression.split("-");
		// if (moveStringParts.length != 2)
		// 	throw new InvalidMoveStringException(moveString);
		
		var fromCellString = moveStringParts[0];
		var toCellString = moveStringParts[1];
		
		var fromCell = this.GetCellRequest(fromCellString);
		var toCell = this.GetCellRequest(toCellString);

		return new MoveRequest(new SessionIdRequest(this.session.id.value), fromCell, toCell);
	}

	private GetCellRequest(cellName: string) : CellRequest
	{
		// if (cellName.Length != 2)
		// 	throw new InvalidCellNameException(cellName);
		// var xName = cellName[0];
		// var yName = cellName[1];

		// if (xName < 97 || xName > 104) //a -> h
		// 	throw new InvalidCellNameException(cellName);
		// if (yName < 49 || yName > 56) //1 -> 8
		// 	throw new InvalidCellNameException(cellName);

		// var x = xName - 97;
		// var y = yName - 49;
		var x = cellName.charCodeAt(0) - 97;//a -> h
		var y = cellName.charCodeAt(1) - 49;//1 -> 8

		return new CellRequest(x, y)
	}
}

