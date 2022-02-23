import { Component, EventEmitter, Inject, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Board } from '../models/Board';
import { NgxChessBoardService } from 'ngx-chess-board';
import {NgxChessBoardView} from 'ngx-chess-board';
import { Cell } from '../models/Cell';
import { Move } from '../models/Move';

@Component({
  selector: 'app-chess-board',
  templateUrl: './chess-board.component.html'
})
export class ChessBoardComponent implements OnInit {
	@Input() board!: Board;
	@Output() onMove : EventEmitter<Move> = new EventEmitter();
	@ViewChild('boardView', {static: false}) boardView!: NgxChessBoardView;//Using ! as the Non-null assertion operator
	public moveExpression: string = "";

	constructor(private ngxChessBoardService: NgxChessBoardService) {
		
	}

	ngOnInit() {
		this.setBoard(this.board);
	}

	public moveChanged() {
		var moves = this.boardView.getMoveHistory();
		var currentMove = moves[moves.length-1];
		console.log(currentMove);
		this.move(currentMove.move);
	}

	public move(moveExpression: string) {
		this.onMove.emit(this.GetMove(moveExpression));
	}

	public moveWithText() {
		this.move(this.moveExpression);
	}

	public setBoard(board: Board)
	{
		this.board = board;
		console.log(board.FENString);
		console.log(this.boardView.getFEN());
		this.boardView.setFEN(this.board.FENString);
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
