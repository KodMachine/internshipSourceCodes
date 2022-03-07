import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Il, Ilce, Mahalle, PageInfo, TasinmazAllDetailModel, TasinmazPost, TasinmazPut } from '../models/model';
import { ExcelService } from '../services/excel.service';
import { IlService } from '../services/il.service';
import { IlceService } from '../services/ilce.service';
import { MahalleService } from '../services/mahalle.service';
import { TasinmazService } from '../services/tasinmaz.service';

@Component({
  selector: 'app-tasinmaz',
  templateUrl: './tasinmaz.component.html',
  styleUrls: ['./tasinmaz.component.css']
})
export class TasinmazComponent implements OnInit {

  
  Ils : Il[];
  Ilce : Ilce[];
  Mahalles : Mahalle[];
  
  choosenTasinmaz : TasinmazAllDetailModel;
  tasinmazlar : TasinmazAllDetailModel[];
  filter = "";
  pageInfo = new PageInfo("",1);
  Page = 1;

  guncelleForm = new FormGroup({
    Ada: new FormControl('',Validators.required),
    Parsel: new FormControl('',Validators.required),
    Nitelik: new FormControl('',Validators.required),
    Adres: new FormControl('',Validators.required),
    Mahalle: new FormControl('',Validators.required),
    Il: new FormControl('',Validators.required),
    Ilce: new FormControl('',Validators.required),
  });

  constructor(private excelService : ExcelService,
    private ilService : IlService,
    private tasinmazService : TasinmazService,
    private mahalleService : MahalleService,
    private ilceService : IlceService,
    private router: Router,
    private toaster:ToastrService) { }

  ngOnInit() {
    this.getAllTasinmazs();
  }

  onFormSubmit()
  {
    var tmp = new TasinmazPut;
    tmp.ada = parseInt(this.guncelleForm.get('Ada').value);
    tmp.parsel = parseInt(this.guncelleForm.get('Parsel').value);
    tmp.nitelik = this.guncelleForm.get('Nitelik').value;
    tmp.adres = this.guncelleForm.get('Adres').value;
    tmp.mahalleId = parseInt(this.guncelleForm.get('Mahalle').value);
    tmp.tasinmazId = this.choosenTasinmaz.tasinmazId;

    if(this.guncelleForm.valid)
    {
      this.update(tmp);
    }
  }

  navigateToTasinmazEkle()
  {
    this.router.navigateByUrl("/tasinmaz-ekle");
  }
  getAllTasinmazs()
  {
    if(this.filter)
      this.pageInfo.filter = this.filter;
    else
    {
      this.pageInfo.filter = "filtresiz";
    }
    this.pageInfo.pageNumber = this.Page;
    console.log(this.pageInfo);
    this.tasinmazService.getPagedTasinmaz(this.pageInfo).subscribe(data =>{
      this.tasinmazlar = data;
    });
  }
  
  update(tasinmazPut : TasinmazPut)
  {
    this.tasinmazService.updateTasinmazPut(tasinmazPut, tasinmazPut.tasinmazId).subscribe(
    {
      next: x => {
        this.toaster.success("Güncelleme Başarılı");
        this.getAllTasinmazs();
      },
      error: err =>{
        this.toaster.error("Güncelleme Başarısız")
        }
    });
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
    })
  }

  getMahalles(id : number)
  {
    this.mahalleService.getAllMahalles(id).subscribe(Data =>{
      this.Mahalles = Data;
    })
  }

  selectTasinmaz(tasinmazAllDetailModel : TasinmazAllDetailModel)
  {
    this.getIls();
    this.getIlces(tasinmazAllDetailModel.ilId);
    this.getMahalles(tasinmazAllDetailModel.ilceId);
    this.guncelleForm.controls['Il'].setValue(tasinmazAllDetailModel.ilId);
    this.guncelleForm.controls['Ilce'].setValue(tasinmazAllDetailModel.ilceId);
    this.guncelleForm.controls['Mahalle'].setValue(tasinmazAllDetailModel.mahalleId);
    this.guncelleForm.controls['Ada'].setValue(tasinmazAllDetailModel.ada);
    this.guncelleForm.controls['Parsel'].setValue(tasinmazAllDetailModel.parsel);
    this.guncelleForm.controls['Nitelik'].setValue(tasinmazAllDetailModel.nitelik);
    this.guncelleForm.controls['Adres'].setValue(tasinmazAllDetailModel.adres);

    this.choosenTasinmaz = tasinmazAllDetailModel;
  }
  
  deleteTasinmazs(tasinmazDelete : TasinmazAllDetailModel)
  {
    this.choosenTasinmaz=tasinmazDelete;
  }
  permenentDelete()
  {
    this.tasinmazService.deleteTasinmaz(this.choosenTasinmaz.tasinmazId).subscribe(
      {
        next: x => {
          this.toaster.success("Silme Başarılı");
          this.getAllTasinmazs();
        },
        error: err =>{
          this.toaster.error("Silme Başarısız")
          }
      });
  }

  onFilter()
  {
    this.Page = 1;
    this.getAllTasinmazs();
  }
  nextPage()
  {
    this.Page++;
    this.getAllTasinmazs();
  }
  priviousPage()
  {
    if(this.Page >= 1)
    {
      this.Page--;
      this.getAllTasinmazs();
    }
  }
  
  report(tmp:TasinmazAllDetailModel)
  {
    var tmpList = new Array(1);
    tmpList[0]=tmp;
    this.excelService.exportAsExcelFile(tmpList, 'TaşınmazDetail');
  }
}
