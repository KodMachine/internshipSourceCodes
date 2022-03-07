import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ilce } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class IlceService {
  baseUrl = "http://localhost:5000/api/Ilce";
  constructor(private http: HttpClient) { }

  getAllIlces(ilId : number) : Observable<Ilce[]>
  {
    return this.http.get<Ilce[]>(this.baseUrl + "/" + ilId);
  }
}
