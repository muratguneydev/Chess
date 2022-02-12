import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SessionDTO } from '../DTO/SessionDTO';
import { EmptySessionDTO } from '../DTO/EmptySessionDTO';

@Component({
  selector: 'app-create-session',
  templateUrl: './create-session.component.html'
})
export class CreateSessionComponent {
  public session: SessionDTO = new EmptySessionDTO();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    // http.get<SessionDTO>(baseUrl + 'weatherforecast').subscribe(result => {
    //   this.session = result;
    // }, error => console.error(error));

	//http.post('https://localhost:5001/session')
  }

  public createSession() {
    this.http.post<SessionDTO>(this.baseUrl + 'session', null).subscribe(result => {
      this.session = result;
    }, error => console.error(error));
  }

}

