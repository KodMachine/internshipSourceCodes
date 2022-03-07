import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Il } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class IlService {
  baseUrl = "http://localhost:5000/api/Il";
  constructor(private http: HttpClient) { }

  getAllIls() : Observable<Il[]>
  {
    return this.http.get<Il[]>(this.baseUrl);
  }
}
