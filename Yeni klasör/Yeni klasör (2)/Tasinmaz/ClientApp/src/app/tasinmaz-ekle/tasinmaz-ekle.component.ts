import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { parse } from 'querystring';
import { Il, Ilce, Mahalle, TasinmazPost } from '../models/model';
import { IlService } from '../services/il.service';
import { IlceService } from '../services/ilce.service';
import { MahalleService } from '../services/mahalle.service';
import { TasinmazService } from '../services/tasinmaz.service';

@Component({
  selector: 'app-tasinmaz-ekle',
  templateUrl: './tasinmaz-ekle.component.html',
  styleUrls: ['./tasinmaz-ekle.component.css']
})
export class TasinmazEkleComponent implements OnInit {

  Ils : Il[];
  Ilce : Ilce[];
  Mahalles : Mahalle[];

  ekleForm = new FormGroup({
    Ada: new FormControl('',Validators.required),
    Parsel: new FormControl('',Validators.required),
    Nitelik: new FormControl('',Validators.required),
    Adres: new FormControl('',Validators.required),
    Mahalle: new FormControl('',Validators.required),
  });
  constructor(private ilService : IlService,
    private tasinmazService : TasinmazService,
    private mahalleService : MahalleService,
    private ilceService : IlceService,
    private toaster:ToastrService,
    private router: Router) { }

  ngOnInit() {
    this.getIls();
  }

  getIls()
  {
    this.ilService.getAllIls().subscribe(Data => {
      this.Ils = Data;
    });
  }

  getIlces(id : number)
  {
    this.ilceService.getAllIlces(id).subscribe(Data =>{
      this.Ilce = Data;
      this.Mahalles = null;
    })
  }

  getMahalles(id : number)
  {
    this.mahalleService.getAllMahalles(id).subscribe(Data =>{
      this.Mahalles = Data;
    })
  }

  createNewTasinmaz(tasinmazPost : TasinmazPost)
  {
    this.tasinmazService.createTasinmaz(tasinmazPost).subscribe(
    {
      next: x => {
        this.toaster.success("Ekleme Başarılı");
        this.router.navigateByUrl("/tasinmaz");
        this.ekleForm.reset();
      },
      error: err =>{
        this.toaster.error("Ekleme Başarısız")
        }
    });
  }
  onFormSubmit()
  {
    var tmp = new  TasinmazPost();
    tmp.ada = parseInt(this.ekleForm.get('Ada').value);
    tmp.parsel = parseInt(this.ekleForm.get('Parsel').value);
    tmp.nitelik = this.ekleForm.get('Nitelik').value;
    tmp.adres = this.ekleForm.get('Adres').value;
    tmp.mahalleId = parseInt(this.ekleForm.get('Mahalle').value);

    if(this.ekleForm.valid)
    {
      this.createNewTasinmaz(tmp);
    }
  }
}
