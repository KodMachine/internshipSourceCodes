import { Component, OnInit } from '@angular/core';
import { KullaniciService } from '../services/kullanici.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private kullaniciService : KullaniciService) { }

  ngOnInit() {
  }

}
