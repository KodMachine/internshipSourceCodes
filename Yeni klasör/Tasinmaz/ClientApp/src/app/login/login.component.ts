import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { KullaniciTable } from '../models/model';
import { KullaniciService } from '../services/kullanici.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit
{
  
  loginForm = new FormGroup({
    Mail: new FormControl(''),
    Password: new FormControl(''),
  });

  girisYapmisKullanici : KullaniciTable;

  constructor(private kullaniciService:KullaniciService) { }

  ngOnInit() {
  }
  onFormSubmit(): void
  {
    console.log(this.loginForm.value);
    this.login();
  }
  login()
  {
    const loginObserver = 
    {
      next: x => console.log('Observer got a next value: ' + x),
      error: err => console.error('Observer got an error: ' + err),
    };
    this.kullaniciService.login(this.loginForm.value).subscribe(loginObserver);
  }
}
