import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../environment/environment';
import { ClientModel } from '../models/client.model';
import { Observable } from 'rxjs';
import { OkResultModel } from '../../../shared/models/ok-result.model';
import { ClientAccountModel } from '../models/client-account-model';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
    
    private http = inject(HttpClient);
    private apiUrl = `${environment.apiUrl}/client`;

    search(name:string=""):Observable<ClientModel[]>{
      return this.http.get<ClientModel[]>(`${this.apiUrl}?name=${name}`);
    }

    getClientById(id: number): Observable<ClientModel> {
      return this.http.get<ClientModel>(`${this.apiUrl}/${id}`);
    }

    post(request: ClientModel): Observable<OkResultModel> {
      return this.http.post<OkResultModel>(this.apiUrl, request);
    }

    put(id: number, request: ClientModel): Observable<OkResultModel> {
      return this.http.put<OkResultModel>(`${this.apiUrl}/${id}`, request);
    }

    delete(id: number): Observable<OkResultModel> {
      return this.http.delete<OkResultModel>(`${this.apiUrl}/${id}`);
    }

    getAccounts(id: number): Observable<ClientAccountModel[]>  {
      return this.http.get<ClientAccountModel[]>(`${this.apiUrl}/${id}/accounts`);
    }
}
