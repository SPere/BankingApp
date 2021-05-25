import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Currency } from '../models/Currency';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  constructor(private httpClient: HttpClient) { }

  getCurrencies() : Observable<Currency[]> {
    return this.httpClient.get<Currency[]>(`${environment.bankingAppAPI}api/Currencies`);
  }
}
