import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { TasinmazComponent } from './tasinmaz/tasinmaz.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { KullaniciComponent } from './kullanici/kullanici.component';
import { LogComponent } from './log/log.component';
import { KullaniciEkleComponent } from './kullanici-ekle/kullanici-ekle.component';
import { TasinmazEkleComponent } from './tasinmaz-ekle/tasinmaz-ekle.component';
import { ExcelService } from './services/excel.service';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    TasinmazComponent,
    KullaniciComponent,
    LogComponent,
    KullaniciEkleComponent,
    TasinmazEkleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [ExcelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
