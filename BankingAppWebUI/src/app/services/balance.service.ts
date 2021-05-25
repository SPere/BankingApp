import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Balance } from '../models/Balance';

@Injectable({
  providedIn: 'root'
})
export class BalanceService {

  constructor(private httpClient: HttpClient) { 
  }

  GetBalance(userId: number): Observable<Balance> {
    return this.httpClient.get<Balance>(`${environment.bankingAppAPI}api/balances/${userId}`);
  }

}
