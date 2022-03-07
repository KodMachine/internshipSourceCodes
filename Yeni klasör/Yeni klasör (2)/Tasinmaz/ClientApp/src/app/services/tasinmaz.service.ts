import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PageInfo, TasinmazAllDetailModel, TasinmazPost, TasinmazPut } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class TasinmazService
{
  baseUrl = "http://localhost:5000/api/tasinmaz";
  pagedUrl = "http://localhost:5000/api/tasinmaz/paged";

  constructor(private http: HttpClient) { }

  getAllTasinmazs() : Observable<TasinmazAllDetailModel[]>
  {
    return this.http.get<TasinmazAllDetailModel[]>(this.baseUrl);
  }

  createTasinmaz(tasinmazPost : TasinmazPost)
  {
    return this.http.post(this.baseUrl, tasinmazPost);
  }

  updateTasinmazPut(tmp : TasinmazPut, ID : number)
  {
    return this.http.put(this.baseUrl + "/" + ID, tmp);
  }
  
  deleteTasinmaz(ID : number)
  {
    return this.http.delete(this.baseUrl + "/" + ID)
  }

  getPagedTasinmaz(pageInfo : PageInfo) : Observable<TasinmazAllDetailModel[]>
  {
    return this.http.post<TasinmazAllDetailModel[]>(this.pagedUrl , pageInfo);
  }
}
