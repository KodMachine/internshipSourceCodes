import { Identifiers } from "@angular/compiler";

export class Model {
}

export class KullaniciTable
{
    address : string ;
    kullaniciId : number ;
    kullaniciName : string ;
    kullaniciSurname : string ;
    mail : string ;
    rol : boolean ;

}
export class LoginModel
{
    Mail : string ;
    Password : string ;
}

export class girisYapmisKullanici
{
  static KullaniciTable;
}

export class TasinmazAllDetailModel
{
    ilName : string ;
    ilceName : string ;
    mahalleName : string ;
    ada : number ;
    parsel : number ;
    nitelik : string ;
    adres : string ;
    isActive : boolean ;
    ilId : number ;
    ilceId : number ;
    mahalleId : number ;
    tasinmazId : number ;
}

export class KullaniciAllDetailModel
{
    kullaniciId : number ;
    isActive : boolean ;
    kullaniciName : string ;
    kullaniciSurname : string ;
    mail : string ;
    rol : boolean ;
    address : string ;
    password : string ;
}

export class LogTable
{
    logId : number ;
    proccesSuccess : boolean ;
    detail : string ;
    ip : string ;
    dateHour : string ;
    explanation : string ;
}

export class KullaniciPost
{
    kullaniciName : string ;
    kullaniciSurname : string ;
    mail : string ;
    rol : boolean ;
    address : string ;
    password : string ;

    constructor() {
    }
}

export class TasinmazPost
{
  ada : number ;
  parsel : number ;
  nitelik : string ;
  adres : string ;
  mahalleId : number ;
}

export class TasinmazPut
{
  tasinmazId : number ;
  ada : number ;
  parsel : number ;
  nitelik : string ;
  adres : string ;
  mahalleId : number ;
}

export class Il
{
  ilId : number ;
  ilName : string ;
}

export class Ilce
{
  ilceId : number ;
  ilceName : string ;
  ilId : number ;
}

export class Mahalle
{
  mahalleId : number ;
  mahalleName : string ;
  ilceId : number
}

export class PageInfo
{
  pageNumber : number ;
  filter : string ;

  constructor(s : string,n : number)
  {
    this.pageNumber = n ;
    this.filter = s ;
  }
}
