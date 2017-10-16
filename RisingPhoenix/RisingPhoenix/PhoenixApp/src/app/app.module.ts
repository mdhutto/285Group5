import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

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

// test
import { ReferralService } from './referral/referral.service';
import { ReferraldetailsComponent } from './referral/referraldetails/referraldetails.component';
import { ReferrallistComponent } from './referral/referrallist/referrallist.component';
import { ReferralnewComponent } from './referral/referralnew/referralnew.component';
import { ReferraleditComponent } from './referral/referraledit/referraledit.component';

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
    ReferralComponent,
    ReferraldetailsComponent,
    ReferrallistComponent,
    ReferralnewComponent,
    ReferraleditComponent
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
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
          { path: 'referral', component: ReferralComponent }
      ])
  ],
  providers: [ReferralService], //test
  bootstrap: [AppComponent]
})
export class AppModule { }
