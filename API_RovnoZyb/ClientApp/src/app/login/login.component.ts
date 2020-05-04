import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../Models/login.model'
import { ApiService } from '../core/api.service';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model = new LoginModel();
  isError: boolean;
  constructor(
    private apiService: ApiService,
    private notifier: NotifierService,
    private spinner: NgxSpinnerService,
    private router: Router) {



  }

  ngOnInit() {
    this.isError = false;
  }


  OnSubmit() {

    this.spinner.show();

    if (this.model.Email === null) {
      this.notifier.notify('error', 'Please, Enter email');
      this.isError = true;
    }
    else if (!this.validateEmail(this.model.Email)) {
      this.notifier.notify('error', 'Email is not correct format!');
      this.isError = true;
    }

    if (this.model.Password === null) {
      this.notifier.notify('error', 'Please, enter password');
      this.isError = true;
    }

    if (this.isError === false) {

      this.apiService.SignIn(this.model).subscribe(
        data => {

          if (data.status === 200) {
            //vse ok

            window.localStorage.setItem('token', data.token);


            if (this.apiService.isLoggedIn()) {
              
              this.router.navigate(['/']);
            }
            else if (this.apiService.isAdmin()) {
              this.router.navigate(['/admin-panel']);
            }




            this.spinner.hide();
          }
          else {
            for (let i = 0; i < data.errors.length; i++) {
              this.notifier.notify('error', data.errors[i]);
            }
            this.spinner.hide();
          }


        }
      );

    } else {
      this.isError = false;
      this.spinner.hide();
    }

  }

  validateEmail(email: string) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }

}