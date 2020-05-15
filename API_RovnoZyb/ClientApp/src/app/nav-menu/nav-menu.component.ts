import { Component } from '@angular/core';
import { ApiService } from '../core/api.service';
import { Router, provideRoutes } from '@angular/router';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggedIn: boolean;
  isAdmin: boolean;

 

  constructor(
    private apiService: ApiService,
    private router: Router,
    private notifier: NotifierService)
  {
    this.isLoggedIn = this.apiService.isLoggedIn();
    this.isAdmin = this.apiService.isAdmin();
    
    this.apiService.loginStatus.subscribe((status) => {
      this.isLoggedIn = status;
      this.isAdmin = this.apiService.isAdmin();
    });

   


  }


  

  Logout () {
    this.apiService.Logout();
    this.router.navigate(['/']);
  }

  notifyAnketa () {
    if(this.isLoggedIn === false)
    {
        this.notifier.notify('warning', 'Ввойдите в аккаунт!');
    }
  }


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
