import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private urlApi = 'http://localhost:8090/api/users/all';

  constructor(private httpClient: HttpClient) { }

  public getData():Observable<any>{
    return this.httpClient.get<any>(this.urlApi);
  }
  
}
