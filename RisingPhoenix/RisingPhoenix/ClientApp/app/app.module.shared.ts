import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component'; //reference
import { CounterComponent } from './components/counter/counter.component'; //reference
import { HomeComponent } from './components/home/home.component';
import { AdminComponent } from './components/admin/admin.component';
import { DataComponent } from './components/data/data.component';
import { DatabaseComponent } from './components/database/database.component';
import { FacetofaceComponent } from './components/facetoface/facetoface.component';
import { FormsComponent } from './components/forms/forms.component';
import { HeresthemoneyComponent } from './components/heresthemoney/heresthemoney.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ReferralslipComponent } from './components/referralslip/referralslip.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent, //reference
        FetchDataComponent, //reference
        HomeComponent,
        AdminComponent,
        DataComponent,
        DatabaseComponent,
        FacetofaceComponent,
        FormsComponent,
        HeresthemoneyComponent,
        LoginComponent,
        ProfileComponent,
        ReferralslipComponent
    ],
    imports: [
        CommonModule,
        BrowserModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent }, //reference
            { path: 'fetch-data', component: FetchDataComponent }, //reference
            { path: 'admin', component: AdminComponent },
            { path: 'data', component: DataComponent },
            { path: 'database', component: DatabaseComponent },
            { path: 'facetoface', component: FacetofaceComponent },
            { path: 'forms', component: FormsComponent },
            { path: 'heresthemoney', component: HeresthemoneyComponent },
            { path: 'login', component: LoginComponent },
            { path: 'profile', component: ProfileComponent },
            { path: 'referralslip', component: ReferralslipComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
