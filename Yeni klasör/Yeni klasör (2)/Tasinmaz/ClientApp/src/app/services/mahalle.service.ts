import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mahalle } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class MahalleService {
  baseUrl = "http://localhost:5000/api/Mahalle";
  constructor(private http: HttpClient) { }

  getAllMahalles(ilceId : number) : Observable<Mahalle[]>
  {
    return this.http.get<Mahalle[]>(this.baseUrl + "/" + ilceId);
  }
}
