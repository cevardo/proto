import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService } from "../../../services/auth.service";
import { Login } from "../../../models";
import { NavbarService } from '../../../services/navbar.service';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    user: Login = new Login()

    showError: boolean = false;
    spinner: boolean = false;

    constructor(public router: Router, private authService: AuthService, private nav: NavbarService) { }

    ngOnInit(): void {
        this.nav.hide();
        if (this.authService.isLoginError) {
            this.showError = true;
            this.user.password = "";
        }
    }

    onSubmit() {
        this.showError = false;
        this.spinner = true;
        this.authService.login(this.user.email, this.user.password)
            //.finally(() => this.loginning = false)
            .subscribe(r => {
                if (r) this.router.navigate(['dashboard'])
                else {
                    this.showError = true;
                    this.user.password = "";
                }
            }, (error: any) => {
                console.error(error);
                //TODO: display error message --
                this.showError = true;
                this.user.password = "";
                this.spinner = false;
            });
    }

    ngOnDestroy() {
        this.nav.show();
    }
}
