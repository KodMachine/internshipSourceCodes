import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LogTable } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class LogService {
  
  baseUrl = "http://localhost:5000/api/log";

  constructor(private http: HttpClient) {}

  getAllLog() : Observable<LogTable[]>
  {
    return this.http.get<LogTable[]>(this.baseUrl);
  }

}
