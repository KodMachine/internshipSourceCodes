import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { KullaniciEkleComponent } from './kullanici-ekle/kullanici-ekle.component';
import { KullaniciComponent } from './kullanici/kullanici.component';
import { LogComponent } from './log/log.component';
import { LoginComponent } from './login/login.component';
import { TasinmazEkleComponent } from './tasinmaz-ekle/tasinmaz-ekle.component';
import { TasinmazComponent } from './tasinmaz/tasinmaz.component';

const routes: Routes = [
  { path: '',component:LoginComponent},
  { path: 'tasinmaz', component: TasinmazComponent},
  { path: 'kullanici', component: KullaniciComponent},
  { path: 'log', component: LogComponent},
  { path: 'kullanici-ekle', component: KullaniciEkleComponent},
  { path: 'tasinmaz-ekle', component: TasinmazEkleComponent},
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

//this.router.navigate(['/blog']);
