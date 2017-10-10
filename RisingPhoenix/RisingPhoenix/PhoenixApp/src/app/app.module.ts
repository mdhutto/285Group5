import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { DataComponent } from './data/data.component';
import { DatabaseComponent } from './database/database.component';
import { FacetofaceComponent } from './facetoface/facetoface.component';
import { FormsComponent } from './forms/forms.component';
import { HeresthemoneyComponent } from './heresthemoney/heresthemoney.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { ReferralComponent } from './referral/referral.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdminComponent,
    DataComponent,
    DatabaseComponent,
    FacetofaceComponent,
    FormsComponent,
    HeresthemoneyComponent,
    LoginComponent,
    ProfileComponent,
    ReferralComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
