import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private urlApi = 'http://localhost:8090/api/users';

  constructor(private httpClient: HttpClient) { }

  findAllUsers():Observable<UserModel[]>{
    return this.httpClient.get<any>(`${this.urlApi}/all`);
  }

  saveUser(user: UserModel): Observable<any> {
    return this.httpClient.post<any>(`${this.urlApi}/save`, user);
  }

  findUserById(id: number | undefined): Observable<UserModel> {
    return this.httpClient.get<UserModel>(`${this.urlApi}/${id}`);
  }
  
}
