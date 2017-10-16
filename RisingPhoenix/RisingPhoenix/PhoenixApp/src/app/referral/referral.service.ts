//test (whole page)
import { Http } from '@angular/http';
import { Referral } from './referral';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import "rxjs";


@Injectable()
export class ReferralService {

    constructor(private _http: Http) { }

    create(referral: Referral) {
        return this._http.post("/referrals", referral)
            .map(data => data.json()).toPromise()
    }
    destroy(referral: Referral) {
        return this._http.delete("/referrals" + referral.FormID)
            .map(data => data.json()).toPromise()
    }
    update(referral: Referral) {
        return this._http.put("/referrals/" + referral.FormID, referral)
            .map(data => data.json()).toPromise()
    }
    getReferrals(){
        return this._http.get("/referrals")
            .map(data => data.json()).toPromise()
    }
    getReferral(referral: Referral) {
        return this._http.get("/referrals/" + referral.FormID)
            .map(data => data.json()).toPromise()
    }

}
