import { Component, OnInit } from '@angular/core';
import { Referral } from './referral'; //test
import { ReferralService } from './referral.service'; //test

@Component({
    selector: 'app-referral',
    templateUrl: './referral.component.html',
    styleUrls: ['./referral.component.css']
})
export class ReferralComponent implements OnInit {
    // test
    referrals: Array<Referral> = [
    //    new Referral(1, 1, "Oct10", "Me", "You", "Her", "Hello"),
    //    new Referral(1, 2, "Oct10", "Me", "You", "Her", "Hello"),
    //   new Referral(1, 3, "Oct10", "Me", "You", "Her", "Hello")
    ];

    constructor(private _referralService: ReferralService) { }

    ngOnInit() {
        //    this.getReferrals();
    }

    getReferrals() {
        //    this._referralService.getReferrals()
        // .then(referrals => this.referrals = referrals)
    }
}
