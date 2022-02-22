import { Component, EventEmitter, Inject, Input, OnInit, Output, ViewChild } from '@angular/core';
import { EmptyBoard } from '../models/EmptyBoard';
import { Board } from '../models/Board';
import { NgxChessBoardService } from 'ngx-chess-board';
import {NgxChessBoardView} from 'ngx-chess-board';
import { MoveRequest } from '../Request/MoveRequest';
import { HttpClient } from '@angular/common/http';
import { SessionDTO } from '../DTO/SessionDTO';
import { EmptySessionDTO } from '../DTO/EmptySessionDTO';
import { PieceFactory } from '../models/Pieces/PieceFactory';
import { SessionIdRequest } from '../Request/SessionIdRequest';
import { CellRequest } from '../Request/CellRequest';
import { SessionIdDTO } from '../DTO/SessionIdDTO';
import { Cell } from '../models/Cell';
import { Move } from '../models/Move';

@Component({
  selector: 'app-chess-board',
  templateUrl: './chess-board.component.html'
})
export class ChessBoardComponent implements OnInit {
	//public session: SessionDTO = new EmptySessionDTO();
	@Input() board!: Board;// = new EmptyBoard();
	//public board: Board = new EmptyBoard();
	@Output() onMove : EventEmitter<Move> = new EventEmitter();
	@ViewChild('boardView', {static: false}) boardView!: NgxChessBoardView;//Using ! as the Non-null assertion operator
	
	constructor(private ngxChessBoardService: NgxChessBoardService) {
		
	}

	ngOnInit() {
		this.setBoard(this.board);
	}

	public moveChanged() {
		var moves = this.boardView.getMoveHistory();
		var currentMove = moves[moves.length-1];
		console.log(currentMove);
		this.onMove.emit(this.GetMove(currentMove.move));
	}

	public setBoard(board: Board)
	{
		//this.board = new Board(this.board, this.pieceFactory);
		//console.log(result);
		//this.boardView.setFEN(this.board.FENString);
		this.board = board;
		console.log(board.FENString);
		console.log(this.boardView.getFEN());
		this.boardView.setFEN(this.board.FENString);
		//this.boardView.setFEN("RNBQKBNR/PPPP1PPP/11111111/1111P111/1111p111/11111111/pppp1ppp/rnbqkbnr");
	}

	private GetMove(moveExpression: string) : Move
	{
		var fromCellString = moveExpression.substring(0,2);
		var toCellString = moveExpression.substring(2,4);

		return new Move(this.GetCell(fromCellString), this.GetCell(toCellString));
	}

	private GetCell(cellName: string) : Cell
	{
		var x = cellName.charCodeAt(0) - 97;//a -> h
		var y = cellName.charCodeAt(1) - 49;//1 -> 8

		return this.board.GetCell(x, y);
	}
}
