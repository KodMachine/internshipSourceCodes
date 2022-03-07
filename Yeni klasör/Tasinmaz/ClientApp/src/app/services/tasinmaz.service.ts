import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TasinmazAllDetailModel } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class TasinmazService 
{
  baseUrl = "http://localhost:5000/api/tasinmaz";

  constructor(private http: HttpClient) { }

  getAllTasinmazs() : Observable<TasinmazAllDetailModel[]>
  {
    return this.http.get<TasinmazAllDetailModel[]>(this.baseUrl);
  }
}
