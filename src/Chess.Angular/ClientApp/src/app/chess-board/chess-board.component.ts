import { Component, Inject, Input } from '@angular/core';
import { EmptyBoard } from '../models/EmptyBoard';
import { Board } from '../models/Board';

@Component({
  selector: 'app-chess-board',
  templateUrl: './chess-board.component.html'
})
export class ChessBoardComponent {
	@Input() board: Board = new EmptyBoard();

}
