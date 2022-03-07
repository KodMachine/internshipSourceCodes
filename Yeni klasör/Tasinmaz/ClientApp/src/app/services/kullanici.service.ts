import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { KullaniciTable, LoginModel } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class KullaniciService 
{
  baseUrl = "http://localhost:5000/api/kullanici";
  loginUrl = "http://localhost:5000/api/kullanici/login";

  constructor(private http: HttpClient) { }

  login(tmp : any)
  {
    return this.http.post(this.loginUrl,tmp);
  }
}
