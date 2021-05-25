import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { 
  }

  getUsers() : Observable<User[]> {
    return this.httpClient.get<User[]>(`${environment.bankingAppAPI}api/Users`);
  }
}
