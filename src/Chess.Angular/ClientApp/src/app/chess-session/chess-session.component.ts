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
		var moveRequest = new MoveRequest(new SessionIdRequest(this.session.id.value), new CellRequest(0, 1), new CellRequest(0, 3));
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
}

