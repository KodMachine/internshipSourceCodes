import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { KullaniciAllDetailModel, KullaniciTable } from '../models/model';
import { KullaniciService } from '../services/kullanici.service';

@Component({
  selector: 'app-kullanici',
  templateUrl: './kullanici.component.html',
  styleUrls: ['./kullanici.component.css']
})
export class KullaniciComponent implements OnInit {
  
  chosenKullanici : KullaniciAllDetailModel;
  kullanicilar : KullaniciAllDetailModel[];
 
  guncelleForm = new FormGroup({
    kullaniciName: new FormControl(''),
    kullaniciSurname: new FormControl(''),
    rol: new FormControl(''),
    mail: new FormControl(''),
    password: new FormControl(''),
    address: new FormControl('')
  });

  constructor(private  kullaniciService : KullaniciService,private router: Router,private toaster:ToastrService) { }

  ngOnInit() {
    this.getAllKullanicis();
  }

  getAllKullanicis()
  {
    this.kullaniciService.getAllKullanici().subscribe(data =>{
      this.kullanicilar = data;
    });
  }

  isAdmin(rol : boolean)
  {
    return rol ? "Admin" : "Kullanıcı";
  }
  isAdminString(rol : string) : boolean
  {
    if(rol == "true")
    return true;
    else
    return false;
  }

  navigateToKullaniciEkle()
  {
    this.router.navigateByUrl("/kullanici-ekle");
  }
  update(kullaniciPut : KullaniciAllDetailModel)
  {
    this.kullaniciService.updateKullaniciPut(kullaniciPut, kullaniciPut.kullaniciId).subscribe(
    {
      next: x => {
        this.toaster.success("Güncelleme Başarılı");
        this.getAllKullanicis();
      },
      error: err =>{
        this.toaster.error("Güncelleme Başarısız")
        }
    });
  }
  onFormSubmit()
  {
    var tmp = new  KullaniciAllDetailModel();
    tmp.kullaniciName = this.guncelleForm.get('kullaniciName').value;
    tmp.kullaniciSurname = this.guncelleForm.get('kullaniciSurname').value;
    tmp.mail = this.guncelleForm.get('mail').value;
    tmp.password = this.guncelleForm.get('password').value;
    tmp.address = this.guncelleForm.get('address').value;
    tmp.rol = this.isAdminString(this.guncelleForm.get('rol').value);
    tmp.kullaniciId = this.chosenKullanici.kullaniciId;

    this.update(tmp);
  }

  saveKullaniciInfo(selected : KullaniciAllDetailModel)
  {
    this.chosenKullanici = selected;
    this.guncelleForm.controls['kullaniciName'].setValue(selected.kullaniciName);
    this.guncelleForm.controls['kullaniciSurname'].setValue(selected.kullaniciSurname);
    this.guncelleForm.controls['rol'].setValue(selected.rol);
    this.guncelleForm.controls['mail'].setValue(selected.mail);
    this.guncelleForm.controls['address'].setValue(selected.address);
  }

  deleteKullanicis(kullaniciDelete : KullaniciAllDetailModel)
  {
    this.chosenKullanici=kullaniciDelete;
  }
  permenentDelete()
  {
    this.kullaniciService.deleteKullanici(this.chosenKullanici.kullaniciId).subscribe(
      {
        next: x => {
          this.toaster.success("Silme Başarılı");
          this.getAllKullanicis();
        },
        error: err =>{
          this.toaster.error("Silme Başarısız")
          }
      });
  }
}
