import { Component, OnInit } from '@angular/core';
import { LogTable, PageInfo } from '../models/model';
import { ExcelService } from '../services/excel.service';
import { LogService } from '../services/log.service';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit {

  log : LogTable[];
  filter = "";
  pageInfo = new PageInfo("",1);
  Page = 1;
  constructor(private excelService :ExcelService,private logService : LogService) { }

  ngOnInit() {
    this.getAllLogs();
  }

  getAllLogs()
  {
    if(this.filter)
      this.pageInfo.filter = this.filter;
    else
    {
      this.pageInfo.filter = "filtresiz";
    }
    this.pageInfo.pageNumber = this.Page;
    console.log(this.pageInfo);
    this.logService.getPagedLog(this.pageInfo).subscribe(data =>{
      this.log = data;
    });
  }

  isSuccess(proccesSuccess : boolean)
  {
    return proccesSuccess ? "Başarılı" : "Başarısız";
  }

  onFilter()
  {
    this.Page = 1;
    this.getAllLogs();
  }
  nextPage()
  {
    this.Page++;
    this.getAllLogs();
  }
  priviousPage()
  {
    if(this.Page >= 1)
    {
      this.Page--;
      this.getAllLogs();
    }
  }

  report()
  {
    this.excelService.exportAsExcelFile(this.log, 'KullaniciDetail');
  }
}
