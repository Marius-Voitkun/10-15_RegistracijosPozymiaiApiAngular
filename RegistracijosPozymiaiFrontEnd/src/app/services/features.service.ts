import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Feature } from '../models/feature';

@Injectable({
  providedIn: 'root'
})
export class FeaturesService {

  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getFeatures(): Observable<Feature[]> {
    return this.http.get<Feature[]>("https://localhost:44337/api/Features");
  }
}
