import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { NgxChessBoardModule } from "ngx-chess-board";

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { ChessSessionComponent } from './chess-session/chess-session.component';
import { ChessBoardComponent } from './chess-board/chess-board.component';
import { PieceFactory } from './models/Pieces/PieceFactory';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
	ChessSessionComponent,
	ChessBoardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'chess-session', component: ChessSessionComponent },
      { path: 'chess-board', component: ChessBoardComponent },
    ]),
	NgxChessBoardModule.forRoot()
  ],
  providers: [PieceFactory],
  bootstrap: [AppComponent]
})
export class AppModule { }
