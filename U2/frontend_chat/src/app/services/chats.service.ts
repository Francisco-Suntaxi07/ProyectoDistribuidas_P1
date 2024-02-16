import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChatsModel } from '../models/ChatsModel';

@Injectable({
  providedIn: 'root'
})
export class ChatsService {
  
  private urlApi = 'http://localhost:8080/api/chats';

  constructor(private httpClient: HttpClient) { }

  findAllChats():Observable<ChatsModel[]>{
    return this.httpClient.get<any>(`${this.urlApi}/all`);
  }

  saveChats(chats: ChatsModel): Observable<any> {
    return this.httpClient.post<any>(`${this.urlApi}/save`, chats);
  }

  findChatsById(id: number): Observable<ChatsModel> {
    return this.httpClient.get<ChatsModel>(`${this.urlApi}/${id}`);
  }
  
}
