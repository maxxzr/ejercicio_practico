import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountModel } from '../model/account.mode';
import { OkResultModel } from '../../../shared/models/ok-result.model';
import { environment } from '../../../../environment/environment';
import { TransactionModel } from '../../transactions/models/transaction.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
    
    private http = inject(HttpClient);
    private apiUrl = `${environment.apiUrl}/account`;

    search(name:string=""):Observable<AccountModel[]>{
      return this.http.get<AccountModel[]>(`${this.apiUrl}?name=${name}`);
    }

    get(id: number): Observable<AccountModel> {
      return this.http.get<AccountModel>(`${this.apiUrl}/${id}`);
    }

    post(request: AccountModel): Observable<OkResultModel> {
      return this.http.post<OkResultModel>(this.apiUrl, request);
    }

    put(id: number, request: AccountModel): Observable<OkResultModel> {
      return this.http.put<OkResultModel>(`${this.apiUrl}/${id}`, request);
    }

    delete(id: number): Observable<OkResultModel> {
      return this.http.delete<OkResultModel>(`${this.apiUrl}/${id}`);
    }

    getTransactions(id:number):Observable<TransactionModel[]>{
      return this.http.get<TransactionModel[]>(`${this.apiUrl}/${id}/transactions`);
    }
    
    postTransaction(id:number, request: TransactionModel):Observable<OkResultModel>{
      return this.http.post<OkResultModel>(`${this.apiUrl}/${id}/transaction`, request);
    }
}
