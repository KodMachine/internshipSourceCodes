import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { KullaniciAllDetailModel, KullaniciTable, PageInfo, TasinmazAllDetailModel } from '../models/model';
import { ExcelService } from '../services/excel.service';
import { KullaniciService } from '../services/kullanici.service';
import { TasinmazService } from '../services/tasinmaz.service';

@Component({
  selector: 'app-kullanici',
  templateUrl: './kullanici.component.html',
  styleUrls: ['./kullanici.component.css']
})
export class KullaniciComponent implements OnInit {
  
  chosenKullanici : KullaniciAllDetailModel;
  kullanicilar : KullaniciAllDetailModel[];
  filter = "";
  pageInfo = new PageInfo("",1);
  Page = 1;
 
  guncelleForm = new FormGroup({
    kullaniciName: new FormControl('',Validators.required),
    kullaniciSurname: new FormControl('',Validators.required),
    rol: new FormControl('',Validators.required),
    mail: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required),
    address: new FormControl('',Validators.required)
  });

  constructor(private excelService : ExcelService,private  kullaniciService : KullaniciService,private router: Router,private toaster:ToastrService) { }

  ngOnInit() {
    this.getAllKullanicis();
  }

  getAllKullanicis()
  {
    if(this.filter)
      this.pageInfo.filter = this.filter;
    else
    {
      this.pageInfo.filter = "filtresiz";
    }
    this.pageInfo.pageNumber = this.Page;
    console.log(this.pageInfo);
    this.kullaniciService.getPagedKullanici(this.pageInfo).subscribe(data =>{
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
    
    if(this.guncelleForm.valid)
    {
      this.update(tmp);
    }
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

  onFilter()
  {
    this.Page = 1;
    this.getAllKullanicis();
  }
  nextPage()
  {
    this.Page++;
    this.getAllKullanicis();
  }
  priviousPage()
  {
    if(this.Page >= 1)
    {
      this.Page--;
      this.getAllKullanicis();
    }
  }
  report(tmp:KullaniciAllDetailModel)
  {
    var tmpList = new Array(1);
    tmpList[0]=tmp;
    this.excelService.exportAsExcelFile(tmpList, 'KullaniciDetail');
  }

}
