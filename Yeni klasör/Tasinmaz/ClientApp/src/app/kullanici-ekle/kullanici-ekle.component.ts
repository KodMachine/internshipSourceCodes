import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { KullaniciPost } from '../models/model';
import { KullaniciService } from '../services/kullanici.service';

@Component({
  selector: 'app-kullanici-ekle',
  templateUrl: './kullanici-ekle.component.html',
  styleUrls: ['./kullanici-ekle.component.css']
})
export class KullaniciEkleComponent implements OnInit {

  ekleForm = new FormGroup({
    kullaniciName: new FormControl(''),
    kullaniciSurname: new FormControl(''),
    rol: new FormControl(''),
    mail: new FormControl(''),
    password: new FormControl(''),
    address: new FormControl('')
  });
  
  constructor(private kullaniciService : KullaniciService,private toaster:ToastrService,private router: Router) { }

  ngOnInit() {
  }

  isAdmin(rol : string) : boolean
  {
    if(rol == "true")
    return true;
    else
    return false;
  }
  createNewKullanici(kullaniciPost : KullaniciPost)
  {
    this.kullaniciService.createKullanici(kullaniciPost).subscribe(
    {
      next: x => {
        this.toaster.success("Ekleme Başarılı");
        this.router.navigateByUrl("/kullanici");
        this.ekleForm.reset();
      },
      error: err =>{
        this.toaster.error("EKleme Başarısız")
        }
    });
  }
  onFormSubmit()
  {
    var tmp = new  KullaniciPost();
    tmp.kullaniciName = this.ekleForm.get('kullaniciName').value;
    tmp.kullaniciSurname = this.ekleForm.get('kullaniciSurname').value;
    tmp.mail = this.ekleForm.get('mail').value;
    tmp.password = this.ekleForm.get('password').value;
    tmp.address = this.ekleForm.get('address').value;
    tmp.rol = this.isAdmin(this.ekleForm.get('rol').value);

    this.createNewKullanici(tmp);
  }
}
