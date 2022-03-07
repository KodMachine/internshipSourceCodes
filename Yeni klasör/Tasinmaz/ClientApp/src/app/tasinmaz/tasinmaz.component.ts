import { Component, OnInit } from '@angular/core';
import { TasinmazAllDetailModel } from '../models/model';
import { TasinmazService } from '../services/tasinmaz.service';

@Component({
  selector: 'app-tasinmaz',
  templateUrl: './tasinmaz.component.html',
  styleUrls: ['./tasinmaz.component.css']
})
export class TasinmazComponent implements OnInit {

  tasinmazlar : TasinmazAllDetailModel[]

  constructor(private tasinmazService : TasinmazService) { }

  ngOnInit() {
    this.getAllTasinmazs();
  }

  getAllTasinmazs()
  {
    this.tasinmazService.getAllTasinmazs().subscribe(data =>{
      this.tasinmazlar = data;
    });
  }
}
