import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LogTable, PageInfo } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class LogService {
  
  baseUrl = "http://localhost:5000/api/log";
  pagedUrl = "http://localhost:5000/api/log/paged";

  constructor(private http: HttpClient) {}

  getAllLog() : Observable<LogTable[]>
  {
    return this.http.get<LogTable[]>(this.baseUrl);
  }
  
  getPagedLog(pageInfo : PageInfo) : Observable<LogTable[]>
  {
    return this.http.post<LogTable[]>(this.pagedUrl , pageInfo);
  }
}
