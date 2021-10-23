import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FormRecord } from '../models/form-record';

@Injectable({
  providedIn: 'root'
})
export class FormValuesService {

  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getData(id: number): Observable<FormRecord> {
    return this.http.get<FormRecord>(`https://localhost:44337/api/FormValues/${id}`);
  }

  public updateData(newData: FormRecord, id: number): Observable<FormRecord> {
    return this.http.put<FormRecord>(`https://localhost:44337/api/FormValues/${id}`, newData);
  }
}
