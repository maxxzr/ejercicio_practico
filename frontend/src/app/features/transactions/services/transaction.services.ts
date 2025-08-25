import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OkResultModel } from '../../../shared/models/ok-result.model';
import { environment } from '../../../../environment/environment';
import { TransactionModel } from '../../transactions/models/transaction.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
    
    private http = inject(HttpClient);
    private apiUrl = `${environment.apiUrl}/transaction`;

    search(name:string=""):Observable<TransactionModel[]>{
      return this.http.get<TransactionModel[]>(`${this.apiUrl}?name=${name}`);
    }

    get(id: number): Observable<TransactionModel> {
      return this.http.get<TransactionModel>(`${this.apiUrl}/${id}`);
    }

    post(request: TransactionModel): Observable<OkResultModel> {
      return this.http.post<OkResultModel>(this.apiUrl, request);
    }

    put(id: number, request: TransactionModel): Observable<OkResultModel> {
      return this.http.put<OkResultModel>(`${this.apiUrl}/${id}`, request);
    }

    delete(id: number): Observable<OkResultModel> {
      return this.http.delete<OkResultModel>(`${this.apiUrl}/${id}`);
    }
}
