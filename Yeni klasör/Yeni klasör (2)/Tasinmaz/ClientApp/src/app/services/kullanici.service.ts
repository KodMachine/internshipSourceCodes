import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { KullaniciAllDetailModel, KullaniciPost, KullaniciTable, LoginModel, PageInfo } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class KullaniciService 
{
  baseUrl = "http://localhost:5000/api/kullanici";
  loginUrl = "http://localhost:5000/api/kullanici/login";
  pagedUrl = "http://localhost:5000/api/kullanici/paged";

  rol : boolean ;
  kullaniciId : number ;

  constructor(private http: HttpClient) { }

  login(tmp : any)
  {
    return this.http.post(this.loginUrl,tmp).pipe(
      map((data : KullaniciTable) => {
      this.rol = data.rol;
      this.kullaniciId = data.kullaniciId;
    }));
  }
  getAllKullanici() :Observable<KullaniciAllDetailModel[]>
  {
    return this.http.get<KullaniciAllDetailModel[]>(this.baseUrl);
  }
  createKullanici(kullaniciPost : KullaniciPost)
  {
    return this.http.post(this.baseUrl, kullaniciPost);
  }

  updateKullaniciPut(tmp : KullaniciAllDetailModel, ID : number)
  {
    return this.http.put(this.baseUrl + "/" + ID, tmp);
  }

  deleteKullanici(ID : number)
  {
    return this.http.delete(this.baseUrl + "/" + ID);
  }

  getPagedKullanici(pageInfo : PageInfo) : Observable<KullaniciAllDetailModel[]>
  {
    return this.http.post<KullaniciAllDetailModel[]>(this.pagedUrl , pageInfo);
  }

}
