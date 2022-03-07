import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { KullaniciTable } from '../models/model';
import { KullaniciService } from '../services/kullanici.service';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { Router } from '@angular/router';

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

  constructor(private kullaniciService:KullaniciService,private toaster:ToastrService,private router: Router) { }

  ngOnInit() {
  }
  onFormSubmit(): void
  {
    console.log(this.loginForm.value);
    this.login();
  }
  login()
  {
    this.kullaniciService.login(this.loginForm.value).subscribe(
    {
      next: x => {
        console.log(x);
        this.toaster.success("Giriş Başarılı");
        this.router.navigateByUrl("/tasinmaz");
        this.loginForm.reset();
      },
      error: err =>{
        console.error('Observer got an error: ')
        this.toaster.error("Giriş Başarısız")
        }
    });
  }
}


