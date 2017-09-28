import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { FormsComponent } from './forms/forms.component';
import { DatabaseComponent } from './database/database.component';
import { DataComponent } from './data/data.component';
import { AdminComponent } from './admin/admin.component';
import { HomeComponent } from './home/home.component';
import { ReferralslipComponent } from './referralslip/referralslip.component';
import { FacetofaceComponent } from './facetoface/facetoface.component';
import { HeresthemoneyComponent } from './heresthemoney/heresthemoney.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    FormsComponent,
    DatabaseComponent,
    DataComponent,
    AdminComponent,
    HomeComponent,
    ReferralslipComponent,
    FacetofaceComponent,
    HeresthemoneyComponent,
    LoginComponent
  ],
  imports: [
      BrowserModule, 
      RouterModule.forRoot([
          { path: 'admin', component: AdminComponent },
          { path: 'data', component: DataComponent },
          { path: 'database', component: DatabaseComponent },
          { path: 'facetoface', component: FacetofaceComponent },
          { path: 'forms', component: FormsComponent },
          { path: 'heresthemoney', component: HeresthemoneyComponent },
          { path: 'home', component: HomeComponent },
          { path: 'login', component: LoginComponent },
          { path: 'profile', component: ProfileComponent },
          { path: 'referralslip', component: ReferralslipComponent }
      ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
