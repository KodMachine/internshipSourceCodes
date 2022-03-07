import { Component, OnInit } from '@angular/core';
import { LogTable } from '../models/model';
import { LogService } from '../services/log.service';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit {

  log : LogTable[];
  constructor(private logService : LogService) { }

  ngOnInit() {
    this.getAllLogs();
  }

  getAllLogs()
  {
    this.logService.getAllLog().subscribe(data =>{
      this.log = data;
      console.log(data);
    });
  }

  isSuccess(proccesSuccess : boolean)
  {
    return proccesSuccess ? "Başarılı" : "Başarısız";
  }


}
