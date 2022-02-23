import { Component, Inject, ViewChild } from '@angular/core';
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
import { PieceFactory } from '../models/Pieces/PieceFactory';
import { Move } from '../models/Move';
import { ChessBoardComponent } from '../chess-board/chess-board.component';

@Component({
  selector: 'app-chess-session',
  templateUrl: './chess-session.component.html'
})
export class ChessSessionComponent {
  public session: SessionDTO = new EmptySessionDTO();
  public board: Board = new EmptyBoard();
  public whitePlayerName: string = "";
  public blackPlayerName: string = "";
  @ViewChild(ChessBoardComponent) chessBoard?:ChessBoardComponent;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private pieceFactory: PieceFactory) {

  }

//   ngAfterViewInit() {
//     // child is set
//     this.child.doSomething();
//   }

  	public createSession() {
    	this.http
				.post<SessionDTO>(this.baseUrl + 'session', null)
				.subscribe(result => {
								this.session = result;
								this.board = new Board(this.session.board, this.pieceFactory);
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
								this.board = new Board(this.session.board, this.pieceFactory);
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
								this.board = new Board(this.session.board, this.pieceFactory);
								console.log(result);
							},
							error => console.error(error));
  	}

	public onMove(move: Move) {
		var moveRequest = new MoveRequest(new SessionIdRequest(this.session.id.value),
			new CellRequest(move.from.x, move.from.y), new CellRequest(move.to.x, move.to.y));
		console.log(moveRequest);
		this.http
				.put<SessionDTO>(this.baseUrl + 'move', moveRequest)
				.subscribe(result => {
								this.session = result;
								this.board = new Board(this.session.board, this.pieceFactory);
								this.chessBoard?.setBoard(this.board);
								console.log(result);
							},
							error => console.error(error));
	}
}

